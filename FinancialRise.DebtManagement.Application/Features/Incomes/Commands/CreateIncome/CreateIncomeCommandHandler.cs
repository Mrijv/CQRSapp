using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Commands.CreateIncome
{
    public class CreateIncomeCommandHandler :IRequestHandler<CreateIncomeCommand, CreateIncomeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IFrequencyRepository _frequencyRepository;

        public CreateIncomeCommandHandler(IMapper mapper, IIncomeRepository incomeRepository, IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _incomeRepository = incomeRepository;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<CreateIncomeCommandResponse> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateIncomeCommandResponse();
            var validator = new CreateIncomeCommandValidator(_incomeRepository);
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
                var frequency = await _frequencyRepository.GetByIdAsync(request.FrequencyId);
                if (frequency == null || !frequency.UserId.Equals(request.UserId))
                {
                    response.Message = "UserId with a given frequencyId doesn't exist in the database.";
                    response.Success = false;
                    return response;
                }

                var income = _mapper.Map<Income>(request);
                income = await _incomeRepository.AddAsync(income);
                response.IncomeId = income.IncomeId;

                return response;
            }

            return response;
        }
    }
}
