using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.CreateGoal
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, CreateGoalCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGoalRepository _goalRepository;
        private readonly IDebtRepository _debtRepository;

        public CreateGoalCommandHandler(IMapper mapper, IGoalRepository goalRepository, IDebtRepository debtRepository)
        {
            _mapper = mapper;
            _goalRepository = goalRepository;
            _debtRepository = debtRepository;
        }

        public async Task<CreateGoalCommandResponse> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateGoalCommandResponse();
            var validator = new CreateGoalCommandValidator(_goalRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (response.Success)
            {
                var debts = await _debtRepository.ListAllByUserAsync(request.UserId);

                if (debts.Count > 1)
                {
                    response.Success = false;
                    response.Message = "Can't add any new goal till you get out of debt.";
                    return response;
                }

                var goal = _mapper.Map<Goal>(request);
                goal = await _goalRepository.AddAsync(goal);
                response.GoalId = goal.GoalId;
            }

            return response;
        }
    }
}
