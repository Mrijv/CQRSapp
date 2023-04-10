using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Queries.GetGoalDetail
{
    public class GetGoalDetailQueryHandler : IRequestHandler<GetGoalDetailQuery, GoalDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IGoalRepository _goalRepository;

        public GetGoalDetailQueryHandler(IMapper mapper, IGoalRepository goalRepository)
        {
            _mapper = mapper;
            _goalRepository = goalRepository;
        }

        public async Task<GoalDetailVm> Handle(GetGoalDetailQuery request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetByIdAsync(request.GoalId);

            if(goal == null)
                throw new Exception($"{nameof(Goal)} with the id: {request.GoalId} not found");

            return _mapper.Map<GoalDetailVm>(goal);
        }
    }
}
