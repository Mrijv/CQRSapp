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
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(FinancialRiseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Note>> ListAllByTypeOfNoteForUserAsync(Guid userId, TypeOfNote typeOfNote)
        {
            return await _dbContext.Notes.Where(d => d.UserId.Equals(userId) && d.TypeOfNote.Equals(typeOfNote)).ToListAsync();
        }
    }
}
