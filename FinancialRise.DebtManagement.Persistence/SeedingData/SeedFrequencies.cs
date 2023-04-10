using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.SeedingData
{
    public class SeedFrequencies
    {
        public static List<Frequency> GetFrequencies()
        {
            return new List<Frequency>()
            {
                new Frequency()
                {
                    FrequencyId = Guid.Parse("2EF244DE-A44F-4F08-91FB-7C0445EA7804"),
                    UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Number = 1,
                    Unit = UnitOfFrequency.Month
                }
            };
        }
    }
}
