using System;
using FinancialRise.DebtManagement.Domain.Common;

namespace FinancialRise.DebtManagement.Application.Features.Common
{
    public class FrequencyDto
    {
        public Guid FrequencyId { get; set; }
        public int Number { get; set; } = 0;
        public UnitOfFrequency Unit { get; set; }
    }
}
