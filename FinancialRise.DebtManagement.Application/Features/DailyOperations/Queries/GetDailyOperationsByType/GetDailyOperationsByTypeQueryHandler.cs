using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.DailyOperations.Queries.GetDailyOperationsByType
{
    public class GetDailyOperationsByTypeQueryHandler : IRequestHandler<GetDailyOperationsByTypeQuery, List<DailyOperationVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDailyOperationRepository _dailyOperationRepository;

        public GetDailyOperationsByTypeQueryHandler(IMapper mapper, IDailyOperationRepository dailyOperationRepository)
        {
            _mapper = mapper;
            _dailyOperationRepository = dailyOperationRepository;
        }

        public async Task<List<DailyOperationVm>> Handle(GetDailyOperationsByTypeQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDailyOperationsByTypeQueryValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exception(validationResult.ToString());

            var dailyOperationsOfOneType = await _dailyOperationRepository.ListAllAsyncByOperationType(request.UserId, request.Operation);

            return _mapper.Map<List<DailyOperationVm>>(dailyOperationsOfOneType);
        }
    }
}
