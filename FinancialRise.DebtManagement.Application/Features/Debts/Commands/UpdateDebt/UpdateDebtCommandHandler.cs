using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Features.Debts.Events;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Commands.UpdateDebt
{
    public class UpdateDebtCommandHandler :IRequestHandler<UpdateDebtCommand, UpdateDebtCommandResponse>
    {
        private readonly IDebtRepository _debtRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFrequencyRepository _frequencyRepository;

        public UpdateDebtCommandHandler(IMapper mapper, IFrequencyRepository frequencyRepository, 
            IDebtRepository debtRepository, IMediator mediator)
        {
            _debtRepository = debtRepository;
            _mediator = mediator;
            _mapper = mapper;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<UpdateDebtCommandResponse> Handle(UpdateDebtCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateDebtCommandResponse();
            var debtToUpdate = await _debtRepository.GetByIdAsync(request.DebtId);
            
            //When user try to update sbd's debt
            if (debtToUpdate == null || !debtToUpdate.UserId.Equals(request.UserId))
            {
                response.Message = ($"{nameof(Debt)} with the id: {request.DebtId} not found");
                response.Success = false;
                return response;
            }

            var frequency = await _frequencyRepository.GetByIdAsync(request.FrequencyId);

            if (frequency == null)
            {
                response.Message = "UserId with a given FrequencyId doesn't exist in the database.";
                response.Success = false;
                return response;
            }

            var validator = new UpdateDebtCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }

                return response;
            }

            if (response.Success)
            {
                _mapper.Map(request, debtToUpdate, typeof(UpdateDebtCommand), typeof(Debt));

                await _debtRepository.UpdateAsync(debtToUpdate);

                await _mediator.Publish(new DebtChangedEvent(debtToUpdate), cancellationToken);
            }

            return response;
        }
    }
}
