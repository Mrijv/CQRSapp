using System;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.Repositories
{
    public class SavingRepository :BaseRepository<Saving>, ISavingRepository
    {
        public SavingRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Saving> GetByUserId(Guid userId)
        {
            return await Task.Run(() => _dbContext.Savings.FirstOrDefault(x => x.UserId.Equals(userId)));
        }
    }
}
