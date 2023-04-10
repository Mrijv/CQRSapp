using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Application.Features.Common;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Debts.Queries.GetDebtWithContacts
{
    public class GetDebtWithContactsQueryHandler : IRequestHandler<GetDebtWithContactsQuery, DebtWithContactsVm>
    {
        private readonly IMapper _mapper;
        private readonly IDebtRepository _debtRepository;
        private readonly IAsyncRepository<Frequency> _frequencyRepository;

        public GetDebtWithContactsQueryHandler(IMapper mapper, IDebtRepository debtRepository, IAsyncRepository<Frequency> frequencyRepository)
        {
            _mapper = mapper;
            _debtRepository = debtRepository;
            _frequencyRepository = frequencyRepository;
        }

        public async Task<DebtWithContactsVm> Handle(GetDebtWithContactsQuery request, CancellationToken cancellationToken)
        {
            var debt = _debtRepository.GetDebtWithContactsForUser(request.UserId,request.DebtId);

            if (debt == null)
                throw new Exception($"{nameof(Debt)} with the id: {request.DebtId} not found");

            var debtWithContactsVm = _mapper.Map<DebtWithContactsVm>(debt);

            var frequency = await _frequencyRepository.GetByIdAsync(debt.FrequencyId);
            debtWithContactsVm.InstalmentFrequency = _mapper.Map<FrequencyDto>(frequency);

            return debtWithContactsVm;
        }
    }
}
