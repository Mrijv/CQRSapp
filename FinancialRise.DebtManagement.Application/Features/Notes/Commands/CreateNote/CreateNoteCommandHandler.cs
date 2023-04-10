using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public CreateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateNoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Count> 0)
                throw new Exception(validationResult.ToString());

            var noteToAdd = _mapper.Map<Note>(request);
            noteToAdd = await _noteRepository.AddAsync(noteToAdd);

            return noteToAdd.NoteId;
        }
    }
}
