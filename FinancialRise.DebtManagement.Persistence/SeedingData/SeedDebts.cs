using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.SeedingData
{
    public class SeedDebts
    {
        public static List<Debt> GetDebts()
        {
            return new List<Debt>()
            {
                new Debt()
                {
                    DebtId = Guid.Parse("1EF244DE-A44F-4F08-91FB-7C0445EA7802"),
                    UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Name = "Mortgage",
                    LoanAmount = 300000m,
                    Total = 511005m,
                    Instalment = 1703.35m,
                    FrequencyId = Guid.Parse("2EF244DE-A44F-4F08-91FB-7C0445EA7804"),
                    FirstInstalment = DateTime.Now,
                    LastInstalment = DateTime.Now.AddYears(25),
                    InterestRate = 4.7d,
                    FlatInstalment = true,
                    CreatedBy = "SeedingData",
                    CreatedDate = DateTime.Now
                }
            };
        }
    }
}
