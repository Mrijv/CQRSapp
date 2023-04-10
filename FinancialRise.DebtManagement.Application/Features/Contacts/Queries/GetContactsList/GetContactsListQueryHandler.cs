using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Queries.GetContactsList
{
    public class GetContactsListQueryHandler : IRequestHandler<GetContactsListQuery, List<ContactListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public GetContactsListQueryHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactListVm>> Handle(GetContactsListQuery request, CancellationToken cancellationToken)
        {
            var allContactsOfDebt = await _contactRepository.ListAllOfUserByDebtAsync(request.DebtId, request.UserId);

            return _mapper.Map<List<ContactListVm>>(allContactsOfDebt);
        }
    }
}
