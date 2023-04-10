using System;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Savings.Commands.CreateSaving
{
    public class CreateSavingCommand: IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Decimal TotalSaving { get; set; }
    }
}
