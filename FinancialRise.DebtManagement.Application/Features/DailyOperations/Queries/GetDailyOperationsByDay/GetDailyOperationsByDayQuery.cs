using System;
using System.Collections.Generic;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries.GetDailyOperationsByDay
{
    public class GetDailyOperationsByDayQuery : IRequest<List<DailyOperationVm>>
    {
        public DateTime PickedDay { get; set; }
        public Guid UserId { get; set; }
    }
}
