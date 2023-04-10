using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;
using FluentValidation;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.CreateDailyOperation
{
    public class CreateDailyOperationCommandHandler : IRequestHandler<CreateDailyOperationCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IDailyOperationRepository _dailyOperationRepository;

        public CreateDailyOperationCommandHandler(IMapper mapper, IDailyOperationRepository dailyOperationRepository)
        {
            _mapper = mapper;
            _dailyOperationRepository = dailyOperationRepository;
        }

        public async Task<Guid> Handle(CreateDailyOperationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDailyOperationCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult.ToString());

            var dailyOperation = _mapper.Map<DailyOperation>(request);
            dailyOperation = await _dailyOperationRepository.AddAsync(dailyOperation);

            return dailyOperation.DailyOperationId;
        }
    }
}
