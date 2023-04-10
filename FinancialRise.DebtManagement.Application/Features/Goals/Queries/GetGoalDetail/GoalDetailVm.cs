using System;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalDetail
{
    public class GoalDetailVm
    {
        public Guid GoalId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}
