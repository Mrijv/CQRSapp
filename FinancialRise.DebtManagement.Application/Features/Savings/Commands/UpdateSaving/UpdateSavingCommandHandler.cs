using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Savings.Commands.UpdateSaving
{
    public class UpdateSavingCommandHandler : IRequestHandler<UpdateSavingCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISavingRepository _savingRepository;

        public UpdateSavingCommandHandler(IMapper mapper, ISavingRepository savingRepository)
        {
            _mapper = mapper;
            _savingRepository = savingRepository;
        }

        public async Task<Unit> Handle(UpdateSavingCommand request, CancellationToken cancellationToken)
        {
            var saving = await _savingRepository.GetByUserId(request.Id);

            _mapper.Map(request, saving, typeof(UpdateSavingCommand), typeof(Saving));

            await _savingRepository.UpdateAsync(saving);
            
            return Unit.Value;
        }
    }
}
