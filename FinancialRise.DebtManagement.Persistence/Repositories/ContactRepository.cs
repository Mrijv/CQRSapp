using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialRise.DebtManagement.Persistence.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Contact>> ListAllOfUserByDebtAsync(Guid debtId, Guid userId)
        {
            return await _dbContext.Contacts.Where(d => d.DebtId.Equals(debtId) && d.UserId.Equals(userId)).ToListAsync();
        }
    }
}
