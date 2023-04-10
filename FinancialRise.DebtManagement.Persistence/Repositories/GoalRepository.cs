using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialRise.DebtManagement.Persistence.Repositories
{
    public class GoalRepository: BaseRepository<Goal>, IGoalRepository
    {
        public GoalRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsGoalTitleExists(string title, Guid userId)
        {
            var matches = _dbContext.Goals.Any(x => x.Title.Equals(title)&& x.UserId.Equals(userId));
            return Task.FromResult(matches);
        }

        public async Task<Goal> GetGoalOfUserByTitle(string title, Guid userId)
        {
            return await _dbContext.Goals.FirstOrDefaultAsync(g => g.Title.Equals(title) && g.UserId.Equals(userId));
        }

        public async Task<IReadOnlyList<Goal>> ListAllByUserAsync(Guid userId)
        {
            return await _dbContext.Goals.Where(d => d.UserId.Equals(userId)).ToListAsync();
        }
    }
}
