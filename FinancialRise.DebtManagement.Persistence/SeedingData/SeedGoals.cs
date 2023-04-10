using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.SeedingData
{
    public class SeedGoals
    {
        public static List<Goal> GetGoals()
        {
            return new List<Goal>()
            {
                new Goal()
                {
                    GoalId = Guid.Parse("3EF244DE-A44F-4F08-91FB-7C0445EA7802"),
                    UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Title = "Debt repayment",
                    Amount = 511005m,
                    Deadline = DateTime.Now.AddYears(25),
                    Description = "Evry goal is possible to achieve, the question is how to do this" +
                                  "and what can I sacrifice to get on top (For sure not your health and other people!" +
                                  "In our world we have endless possibilities, try one)?",
                    CreatedBy = "SeedingData",
                    CreatedDate = DateTime.Now
                }
            };
        }
    }
}
