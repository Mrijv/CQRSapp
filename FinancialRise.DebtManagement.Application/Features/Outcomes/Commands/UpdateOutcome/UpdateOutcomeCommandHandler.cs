using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Commands.UpdateOutcome
{
    public class UpdateOutcomeCommandHandler : IRequestHandler<UpdateOutcomeCommand, UpdateOutcomeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOutcomeRepository _outcomeRepository;
        private readonly IFrequencyRepository _frequencyRepository;

        public UpdateOutcomeCommandHandler(IMapper mapper, IOutcomeRepository outcomeRepository, IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _outcomeRepository = outcomeRepository;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<UpdateOutcomeCommandResponse> Handle(UpdateOutcomeCommand request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateOutcomeCommandResponse();
            var outcomeToUpdate = await _outcomeRepository.GetByIdAsync(request.OutcomeId);

            if (outcomeToUpdate == null || !outcomeToUpdate.UserId.Equals(request.UserId))
            {
                response.Message = $"{nameof(Outcome)} with the id: {request.OutcomeId} not found";
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

            var validator = new UpdateOutcomeCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (response.Success)
            {
                _mapper.Map(request, outcomeToUpdate, typeof(UpdateOutcomeCommand), typeof(Outcome));

                await _outcomeRepository.UpdateAsync(outcomeToUpdate);
            }

            return response;
        }
    }
}
