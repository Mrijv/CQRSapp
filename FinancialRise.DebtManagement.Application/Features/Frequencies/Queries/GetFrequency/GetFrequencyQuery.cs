using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Queries.GetFrequency
{
    public class GetFrequencyQuery : IRequest<FrequencyVm>
    {
        public Guid FrequencyId { get; set; }
        public Guid UserId { get; set; }
    }
}
