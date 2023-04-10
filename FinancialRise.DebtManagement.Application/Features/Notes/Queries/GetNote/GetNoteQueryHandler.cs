using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Queries.GetNote
{
    public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, NoteVm>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public GetNoteQueryHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<NoteVm> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            var note = await _noteRepository.GetByIdAsync(request.NoteId);

            if (note == null || !note.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Note)} with the id: {request.NoteId} not found");

            return _mapper.Map<NoteVm>(note);
        }
    }
}
