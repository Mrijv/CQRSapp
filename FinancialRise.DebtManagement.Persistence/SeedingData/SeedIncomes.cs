using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.SeedingData
{
    public class SeedIncomes
    {
        public static List<Income> GetIncomes()
        {
            return new List<Income>()
            {
                new Income()
                {
                    IncomeId = Guid.Parse("{42787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    FrequencyId = Guid.Parse("2EF244DE-A44F-4F08-91FB-7C0445EA7804"),
                    UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Name = "Salary",
                    Amount = 8000,
                    FirstRemit = DateTime.Now,
                    CreatedBy = "SeedingData",
                    CreatedDate = DateTime.Now
                }
            };
        }
    }
}
