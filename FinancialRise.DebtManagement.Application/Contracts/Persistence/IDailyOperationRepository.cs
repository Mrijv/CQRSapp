using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Persistence
{
    public interface IDailyOperationRepository : IAsyncRepository<DailyOperation>
    {
        Task<List<DailyOperation>> ListAllAsyncByOperationType(Guid userId, TypeOfOperation typeOfOperation);
        Task<List<DailyOperation>> ListAllAsyncByDay(Guid userId, DateTime pickedDay);
    }
}
