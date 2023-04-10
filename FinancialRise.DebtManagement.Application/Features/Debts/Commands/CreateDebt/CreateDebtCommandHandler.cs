using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Contracts.Services;
using FinancialRise.DebtManagement.Application.Features.Debts.Events;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Commands.CreateDebt
{
    public class CreateDebtCommandHandler :IRequestHandler<CreateDebtCommand, CreateDebtCommnadResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDebtRepository _debtRepository;
        private readonly IFrequencyRepository _frequencyRepository;
        private readonly ICalculateDebt _calculate;
        private readonly ILogger<CreateDebtCommandHandler> _logger;
        private readonly IMediator _mediator;

        public CreateDebtCommandHandler(IMapper mapper, IDebtRepository debtRepository,IFrequencyRepository frequencyRepository, 
            ICalculateDebt calculate, ILogger<CreateDebtCommandHandler> logger, IMediator mediator)
        {
            _mapper = mapper;
            _debtRepository = debtRepository;
            _frequencyRepository = frequencyRepository;
            _calculate = calculate;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<CreateDebtCommnadResponse> Handle(CreateDebtCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateDebtCommnadResponse();
            var validator = new CreateDebtCommandValidator(_debtRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
                _logger.LogError(validationResult.ToString());
            }

            if (response.Success)
            {
                var frequency = await _frequencyRepository.GetByIdAsync(request.FrequencyId);
                if (frequency == null || !frequency.UserId.Equals(request.UserId))
                {
                    response.Message = "UserId with a given frequencyId doesn't exist in the database.";
                    response.Success = false;
                    return response;
                }

                var debt = _mapper.Map<Debt>(request);

                try
                {
                    (debt.Instalment, debt.Total) = await _calculate.CalculateDebtFixedInstalmentAndTotal(debt);
                    if (!request.Instalment.Equals(debt.Instalment) || !request.Total.Equals(debt.Total))
                    {
                        response.Message = "Instalment or Total was changed during the calculation, " +
                                           "if you didn't put wrong data, please feel free to edit your " +
                                           "debt as you wish using Update functionality.";
                    }

                    debt = await _debtRepository.AddAsync(debt);
                    response.Id = debt.DebtId;

                    await _mediator.Publish(new DebtChangedEvent(debt), cancellationToken);
                }
                catch (Exception e)
                {
                    response.Success = false;
                    response.Message = $"CalculateDebt class threw an exception: {e}";
                    return response;
                }
            }
            return response;
        }
    }
}
