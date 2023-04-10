using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.Repositories
{
    public class FrequencyRepository : BaseRepository<Frequency>, IFrequencyRepository
    {
        public FrequencyRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
