using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler :IRequestHandler<UpdateNoteCommand>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public UpdateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var noteToUpdate = await _noteRepository.GetByIdAsync(request.NoteId);

            if(noteToUpdate == null)
                throw new Exception($"{nameof(Note)} with the id: {request.NoteId} not found");

            var validator = new UpdateNoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exception(validationResult.ToString());

            _mapper.Map(request, noteToUpdate, typeof(UpdateNoteCommand), typeof(Note));
            await _noteRepository.UpdateAsync(noteToUpdate);

            return Unit.Value;
        }
    }
}
