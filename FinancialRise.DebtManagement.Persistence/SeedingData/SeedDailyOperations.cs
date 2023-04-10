using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.SeedingData
{
    public class SeedDailyOperations
    {
        public static List<DailyOperation> GetDailyOperations()
        {
            return new List<DailyOperation>()
            {
                new DailyOperation()
                {
                    DailyOperationId = new Guid("6EF244DE-A44F-4F08-91FB-7C0445EA7807"),
                    UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Name = "Dinner",
                    Amount = -300.5m,
                    CreatedBy = "SeedingData",
                    CreatedDate = DateTime.Now,
                    Operation = TypeOfOperation.DailyOutcome
                },

                new DailyOperation()
                {
                    DailyOperationId = new Guid("6EF244DE-A44F-4F08-91FB-7C0445EA7801"),
                    UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Name = "From salary",
                    Amount = 400m,
                    CreatedBy = "SeedingData",
                    CreatedDate = DateTime.Now,
                    Operation = TypeOfOperation.Saving
                }
            };
        }
    }
}
