using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommand :IRequest
    {
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public Guid DebtId { get; set; }
    }
}
