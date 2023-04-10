using System;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalList
{
    public class GoalListVm
    {
        public Guid GoalId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
    }
}
