using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.UpdateFrequency
{
    public class UpdateFrequencyCommand :IRequest
    {
        public Guid FrequencyId { get; set; }
        public Guid UserId { get; set; }
        public int Number { get; set; } = 0;
        public UnitOfFrequencyDtoType Unit { get; set; }
    }
}
