using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Persistence
{
    public interface INoteRepository : IAsyncRepository<Note>
    {
        Task<IReadOnlyList<Note>> ListAllByTypeOfNoteForUserAsync(Guid userId, TypeOfNote typeOfNote);
    }
}
