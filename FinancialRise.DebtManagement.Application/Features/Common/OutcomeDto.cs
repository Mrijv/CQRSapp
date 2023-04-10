using System;

namespace FinancialRise.DebtManagement.Application.Features.Common
{
    public class OutcomeDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public Decimal Amount { get; set; }
        public FrequencyDto Frequency { get; set; }
        public DateTime FirstRemit { get; set; }
        public DateTime LastRemit { get; set; }
    }
}
