using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INoteRepository _noteRepository;

        public DeleteNoteCommandHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var noteToDelete = await _noteRepository.GetByIdAsync(request.NoteId);

            if(noteToDelete == null)
                throw new Exception($"{nameof(Note)} with the id: {request.NoteId} not found");

            await _noteRepository.DeleteAsync(noteToDelete);

            return Unit.Value;
        }
    }
}
