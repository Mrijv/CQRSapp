using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialRise.DebtManagement.Persistence.Repositories
{
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsIncomeNameExists(string name)
        {
            var matches = _dbContext.Incomes.Any(x => x.Name.Equals(name));
            return Task.FromResult(matches);
        }

        public async Task<IReadOnlyList<Income>> ListAllByUserAsync(Guid userId)
        {
            return await _dbContext.Incomes.Where(d => d.UserId.Equals(userId)).Include(f=>f.Frequency).ToListAsync();
        }
    }
}
