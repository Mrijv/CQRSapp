using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Savings.Queries.GetSaving
{
    public class GetSavingQueryHandler :IRequestHandler<GetSavingQuery, SavingVm>
    {
        private readonly IMapper _mapper;
        private readonly ISavingRepository _savingRepository;

        public GetSavingQueryHandler(IMapper mapper, ISavingRepository savingRepository)
        {
            _mapper = mapper;
            _savingRepository = savingRepository;
        }

        public async Task<SavingVm> Handle(GetSavingQuery request, CancellationToken cancellationToken)
        {
            var userSaving = await _savingRepository.GetByUserId(request.UserId);

            return userSaving == null ? null : _mapper.Map<SavingVm>(userSaving);
        }
    }
}
