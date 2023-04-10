using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Queries.GetIncomesList
{
    public class GetIncomesListQueryHandler : IRequestHandler<GetIncomesListQuery, List<IncomesListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IFrequencyRepository _frequencyRepository;

        public GetIncomesListQueryHandler(IMapper mapper, IIncomeRepository incomeRepository, IFrequencyRepository frequencyRepository)
        {
            _mapper = mapper;
            _incomeRepository = incomeRepository;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<List<IncomesListVm>> Handle(GetIncomesListQuery request, CancellationToken cancellationToken)
        {
            var incomes = (await _incomeRepository.ListAllByUserAsync(request.UserId))
                .OrderBy(x => x.Amount);

            return _mapper.Map<List<IncomesListVm>>(incomes);
        }
    }
}
