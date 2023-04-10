using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Common;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.SeedingData
{
    public class SeedNotes
    {
        public static List<Note> GetNotes()
        {
            return new List<Note>()
            {
                new Note()
                {
                    NoteId = Guid.Parse("5EF244DE-A44F-4F08-91FB-7C0445EA7804"),
                    UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Content = "I devote myself to achieving the main goal and appreciate this path every day," +
                              " find joy in every progress' step",
                    TypeOfNote = TypeOfNote.Other,
                    CreatedBy = "SeedingData",
                    CreatedDate = DateTime.Now
                }
            };
        }
    }
}
