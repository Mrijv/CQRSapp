using System;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Queries.GetContactsList
{
    public class ContactListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
