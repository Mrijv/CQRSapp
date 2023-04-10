using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Savings.Commands.UpdateSaving
{
    public class UpdateSavingCommand : IRequest
    {
        public Guid Id { get; set; }
        public Decimal TotalSaving { get; set; }
    }
}
