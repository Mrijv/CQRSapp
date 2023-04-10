using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries.GetDailyOperationsByDay
{
    public class GetDailyOperationsByDayQueryHandler: IRequestHandler<GetDailyOperationsByDayQuery, List<DailyOperationVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDailyOperationRepository _dailyOperationRepository;

        public GetDailyOperationsByDayQueryHandler(IMapper mapper, IDailyOperationRepository dailyOperationRepository)
        {
            _mapper = mapper;
            _dailyOperationRepository = dailyOperationRepository;
        }

        public async Task<List<DailyOperationVm>> Handle(GetDailyOperationsByDayQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDailyOperationsByDayQueryValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exception(validationResult.ToString());

            var dailyOperationsOfPickedDay = await _dailyOperationRepository.ListAllAsyncByDay(request.UserId, request.PickedDay);

            return _mapper.Map<List<DailyOperationVm>>(dailyOperationsOfPickedDay);
        }
    }
}
