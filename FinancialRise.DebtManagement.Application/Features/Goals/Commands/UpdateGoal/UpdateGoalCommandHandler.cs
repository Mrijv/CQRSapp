using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, UpdateGoalCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGoalRepository _goalRepository;

        public UpdateGoalCommandHandler(IMapper mapper, IGoalRepository goalRepository)
        {
            _mapper = mapper;
            _goalRepository = goalRepository;
        }

        public async Task<UpdateGoalCommandResponse> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateGoalCommandResponse();
            var goalToUpdate = await _goalRepository.GetByIdAsync(request.GoalId);

            if(goalToUpdate == null || !goalToUpdate.UserId.Equals(request.UserId))
            {
                response.Message = $"{nameof(Goal)} with the id: {request.GoalId} not found";
                response.Success = false;
                return response;
            }

            var validator = new UpdateGoalCommandValidation();
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
                _mapper.Map(request, goalToUpdate, typeof(UpdateGoalCommand), typeof(Goal));

                await _goalRepository.UpdateAsync(goalToUpdate);
            }

            return response;
        }
    }
}
