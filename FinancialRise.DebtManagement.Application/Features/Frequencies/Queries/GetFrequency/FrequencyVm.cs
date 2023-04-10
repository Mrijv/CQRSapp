using System;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Queries.GetFrequency
{
    public class FrequencyVm
    {
        public Guid FrequencyId { get; set; }
        public int Number { get; set; } = 0;
        public UnitOfFrequencyDtoType Unit { get; set; }
    }
}
