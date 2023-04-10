using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialRise.DebtManagement.Persistence.Repositories
{
    public class DailyOperationRepository : BaseRepository<DailyOperation>, IDailyOperationRepository
    {
        public DailyOperationRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<DailyOperation>> ListAllAsyncByOperationType(Guid userId, TypeOfOperation typeOfOperation)
        { 
            return await _dbContext.DailyOperations.Where(x => x.UserId.Equals(userId) && x.Operation.Equals(typeOfOperation)).ToListAsync();
        }

        public async Task<List<DailyOperation>> ListAllAsyncByDay(Guid userId, DateTime pickedDay)
        {
            if (pickedDay == DateTime.MinValue)
                return await _dbContext.DailyOperations.Where(x => x.UserId.Equals(userId) && x.CreatedDate.Date.Equals(DateTime.Now.Date)).ToListAsync();
            else
                return await _dbContext.DailyOperations.Where(x => x.UserId.Equals(userId) && x.CreatedDate.Date.Equals(pickedDay.Date)).ToListAsync();
            
        }
    }
}
