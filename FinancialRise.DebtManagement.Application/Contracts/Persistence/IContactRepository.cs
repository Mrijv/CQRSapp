using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Persistence
{
    public interface IContactRepository : IAsyncRepository<Contact>
    {
        Task<IReadOnlyList<Contact>> ListAllOfUserByDebtAsync(Guid debtId, Guid userId);
    }
}
