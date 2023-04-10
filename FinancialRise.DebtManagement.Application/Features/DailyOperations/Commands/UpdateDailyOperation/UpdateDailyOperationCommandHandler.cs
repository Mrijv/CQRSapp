using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using FluentValidation;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.UpdateDailyOperation
{
    public class UpdateDailyOperationCommandHandler : IRequestHandler<UpdateDailyOperationCommand>
    {
        private readonly IMapper _mapper;
        private readonly IDailyOperationRepository _dailyOperationRepository;

        public UpdateDailyOperationCommandHandler(IMapper mapper, IDailyOperationRepository dailyOperationRepository)
        {
            _mapper = mapper;
            _dailyOperationRepository = dailyOperationRepository;
        }

        public async Task<Unit> Handle(UpdateDailyOperationCommand request, CancellationToken cancellationToken)
        {
            var dailyOperation = await _dailyOperationRepository.GetByIdAsync(request.DailyOperationId);

            if (dailyOperation == null || !dailyOperation.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(DailyOperation)} with the id: {request.DailyOperationId} not found");

            var validator = new UpdateDailyOperationCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult.ToString());

            _mapper.Map(request, dailyOperation, typeof(UpdateDailyOperationCommand), typeof(DailyOperation));

            await _dailyOperationRepository.UpdateAsync(dailyOperation);

            return Unit.Value;
        }
    }
}
