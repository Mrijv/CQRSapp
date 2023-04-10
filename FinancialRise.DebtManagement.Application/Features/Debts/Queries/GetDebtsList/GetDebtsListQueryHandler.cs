using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtsList
{
    public class GetDebtsListQueryHandler : IRequestHandler<GetDebtsListQuery, List<DebtListVm>>
    {
        private readonly IDebtRepository _debtRepository;
        private readonly IMapper _mapper;

        public GetDebtsListQueryHandler(IDebtRepository debtRepository, IMapper mapper)
        {
            _debtRepository = debtRepository;
            _mapper = mapper;
        }

        public async Task<List<DebtListVm>> Handle(GetDebtsListQuery request, CancellationToken cancellationToken)
        {
            var allDebts = (await _debtRepository.ListAllByUserAsync(request.UserId)).OrderBy(x => x.FirstInstalment);

            return _mapper.Map<List<DebtListVm>>(allDebts);
        }
    }
}
