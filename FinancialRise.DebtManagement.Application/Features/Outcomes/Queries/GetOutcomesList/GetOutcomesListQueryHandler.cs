using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Features.Common;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Outcomes.Queries.GetOutcomesList
{
    public class GetOutcomesListQueryHandler : IRequestHandler<GetOutcomesListQuery, List<OutcomesListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IOutcomeRepository _outcomeRepository;
        private readonly IFrequencyRepository _frequencyRepository;

        public GetOutcomesListQueryHandler(IMapper mapper, IOutcomeRepository outcomeRepository, 
             IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _outcomeRepository = outcomeRepository;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<List<OutcomesListVm>> Handle(GetOutcomesListQuery request, CancellationToken cancellationToken)
        {
            var outcomes = (await _outcomeRepository.ListAllByUserAsync(request.UserId))
                .OrderBy(x => x.Amount);
            
            return _mapper.Map<List<OutcomesListVm>>(outcomes);
        }
    }
}
