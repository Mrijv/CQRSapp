using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using FluentValidation;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Commands.UpdateIncome
{
    public class UpdateIncomeCommandHandler : IRequestHandler<UpdateIncomeCommand, UpdateIncomeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IFrequencyRepository _frequencyRepository;

        public UpdateIncomeCommandHandler(IMapper mapper, IIncomeRepository incomeRepository, IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _incomeRepository = incomeRepository;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<UpdateIncomeCommandResponse> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateIncomeCommandResponse();
            var incomeToUpdate = await _incomeRepository.GetByIdAsync(request.IncomeId);

            if (incomeToUpdate == null || !incomeToUpdate.UserId.Equals(request.UserId))
            {
                response.Message = $"{nameof(Income)} with the id: {request.IncomeId} not found";
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

            var validator = new UpdateIncomeCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Count > 0)
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
                _mapper.Map(request, incomeToUpdate, typeof(UpdateIncomeCommand), typeof(Income));

                await _incomeRepository.UpdateAsync(incomeToUpdate);
            }

            return response;
        }
    }
}
