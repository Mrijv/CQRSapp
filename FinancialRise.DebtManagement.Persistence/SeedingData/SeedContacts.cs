using System;
using System.Collections.Generic;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Persistence.SeedingData
{
    public class SeedContacts
    {
        public static List<Contact> GetContacts()
        {
            return new List<Contact>()
            {
                new Contact()
                {
                    ContactId = new Guid("6EF244DE-A44F-4F08-91FB-7C0445EA7807"),
                    Name = "Repossession Man",
                    Address = "ul. Grochowa 24, 65-901 Warszawa",
                    UserId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                    Email = "mkapusta@gmail.com",
                    PhoneNumber = "48789453784",
                    CreatedBy = "SeedingData",
                    CreatedDate = DateTime.Now,
                    DebtId =Guid.Parse("1EF244DE-A44F-4F08-91FB-7C0445EA7802")
                }
            };
        }
    }
}
