using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Features.Notes.Queries.GetNote;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Queries.GetNotes
{
    public class GetNotesByTypeQueryHandler :IRequestHandler<GetNotesByTypeQuery, List<NoteVm>>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public GetNotesByTypeQueryHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<List<NoteVm>> Handle(GetNotesByTypeQuery request, CancellationToken cancellationToken)
        {
            var notes = await _noteRepository.ListAllByTypeOfNoteForUserAsync(request.UserId, request.TypeOfNote);

            return _mapper.Map<List<NoteVm>>(notes);
        }
    }
}
