using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.DeleteFrequency
{
    public class DeleteFrequencyCommand : IRequest
    {
        public Guid FrequencyId { get; set; }
        public Guid UserId { get; set; }
    }
}
