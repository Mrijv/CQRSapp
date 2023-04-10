using System;
using FinancialRise.DebtManagement.Domain.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.CreateDailyOperation
{
    public class CreateDailyOperationCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public TypeOfOperation Operation { get; set; }
        public Guid UserId { get; set; }
    }
}
