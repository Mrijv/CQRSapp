using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialRise.DebtManagement.Persistence.Repositories
{
    public class DebtRepository : BaseRepository<Debt>, IDebtRepository
    {
        public DebtRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }

        public Debt GetDebtWithContactsForUser(Guid userId, Guid debtId)
        {
            return _dbContext.Debts.Where(d=>d.UserId.Equals(userId))
                .Include(x => x.Contacts.Where(c=>c.DebtId.Equals(debtId))).FirstOrDefault();
        }

        public Task<bool> IsDebtNameExists(string name)
        {
            var matches = _dbContext.Debts.Any(x => x.Name.Equals(name));
            return Task.FromResult(matches);
        }

        public async Task<IReadOnlyList<Debt>> ListAllByUserAsync(Guid userId)
        {
            return await _dbContext.Debts.Where(d => d.UserId.Equals(userId)).ToListAsync();
        }
    }
}
