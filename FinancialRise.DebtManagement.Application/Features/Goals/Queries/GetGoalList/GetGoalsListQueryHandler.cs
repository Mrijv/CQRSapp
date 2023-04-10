using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalList
{
    public class GetGoalsListQueryHandler : IRequestHandler<GetGoalsListQuery, List<GoalListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IGoalRepository _goalRepository;

        public GetGoalsListQueryHandler(IMapper mapper, IGoalRepository goalRepository)
        {
            _mapper = mapper;
            _goalRepository = goalRepository;
        }

        public async Task<List<GoalListVm>> Handle(GetGoalsListQuery request, CancellationToken cancellationToken)
        {
            var allByUserGoals = (await _goalRepository.ListAllByUserAsync(request.UserId)).OrderBy(x => x.Deadline);

            return _mapper.Map<List<GoalListVm>>(allByUserGoals);
        }
    }
}
