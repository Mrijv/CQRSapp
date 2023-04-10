using System;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Persistence
{
    public interface ISavingRepository : IAsyncRepository<Saving>
    {
        Task<Saving> GetByUserId(Guid userId);
    }
}
