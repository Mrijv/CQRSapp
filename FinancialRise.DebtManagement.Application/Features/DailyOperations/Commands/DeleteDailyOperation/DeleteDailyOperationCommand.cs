using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Commands.DeleteDailyOperation
{
    public class DeleteDailyOperationCommand : IRequest
    {
        public Guid DailyOperationId { get; set; }
        public Guid UserId { get; set; }
    }
}
