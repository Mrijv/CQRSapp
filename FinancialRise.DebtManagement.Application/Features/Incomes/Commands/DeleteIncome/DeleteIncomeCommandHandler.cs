using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Incomes.Commands.DeleteIncome
{
    public class DeleteIncomeCommandHandler : IRequestHandler<DeleteIncomeCommand>
    {
        private readonly IIncomeRepository _incomeRepository;

        public DeleteIncomeCommandHandler(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task<Unit> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            var incomeToDelete = await _incomeRepository.GetByIdAsync(request.IncomeId);

            if (incomeToDelete == null || !incomeToDelete.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Income)} with the id: {request.IncomeId} not found");

            await _incomeRepository.DeleteAsync(incomeToDelete);

            return Unit.Value;
        }
    }
}
