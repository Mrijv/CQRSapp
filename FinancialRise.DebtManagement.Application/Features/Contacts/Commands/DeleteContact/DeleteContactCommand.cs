using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommand :IRequest
    {
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }
    }
}
