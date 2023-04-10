using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Persistence
{
    public interface IGoalRepository : IAsyncRepository<Goal>
    {
        public Task<bool> IsGoalTitleExists(string title, Guid userId);
        public Task<Goal> GetGoalOfUserByTitle(string title, Guid userId);
        Task<IReadOnlyList<Goal>> ListAllByUserAsync(Guid userId);
    }
}
