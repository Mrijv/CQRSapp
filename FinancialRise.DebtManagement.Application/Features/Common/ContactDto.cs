﻿using System;

namespace FinancialRise.DebtManagement.Application.Features.Common
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
