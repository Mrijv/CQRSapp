using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialRise.DebtManagement.Persistence.Repositories
{
    public class OutcomeRepository : BaseRepository<Outcome>, IOutcomeRepository
    {
        public OutcomeRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsOutcomeNameExists(string name)
        {
            var matches = _dbContext.Outcomes.Any(x => x.Name.Equals(name));
            return Task.FromResult(matches);
        }

        public async Task<IReadOnlyList<Outcome>> ListAllByUserAsync(Guid userId)
        {
            return await _dbContext.Outcomes.Where(d => d.UserId.Equals(userId))
                .Include(x=>x.Frequency).ToListAsync();
        }
    }
}
