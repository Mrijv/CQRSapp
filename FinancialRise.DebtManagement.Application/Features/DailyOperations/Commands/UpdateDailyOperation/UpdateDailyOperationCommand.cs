using System;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.UpdateDailyOperation
{
    public class UpdateDailyOperationCommand :IRequest
    {
        public Guid DailyOperationId { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public Decimal Amount { get; set; }
        public TypeOfOperation Operation { get; set; }
    }
}
