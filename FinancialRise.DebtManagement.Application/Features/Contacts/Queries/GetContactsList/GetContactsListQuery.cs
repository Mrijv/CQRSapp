using System;
using System.Collections.Generic;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Queries.GetContactsList
{
    public class GetContactsListQuery : IRequest<List<ContactListVm>>
    {
        public Guid DebtId { get; set; }
        public Guid UserId { get; set; }
    }
}
