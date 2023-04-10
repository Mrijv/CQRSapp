using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Persistence
{
    public interface IDebtRepository : IAsyncRepository<Debt>
    {
        Debt GetDebtWithContactsForUser(Guid userId, Guid debtId);
        Task<bool> IsDebtNameExists(string name);
        Task<IReadOnlyList<Debt>> ListAllByUserAsync(Guid userId);
    }
}
