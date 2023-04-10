using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.CreateFrequency
{
    public class CreateFrequencyCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public int Number { get; set; } = 0;
        public UnitOfFrequencyDtoType Unit { get; set; }
    }
}
