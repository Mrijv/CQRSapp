using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinancialRise.DebtManagement.Application.Features.Savings.Commands.CreateSaving
{
    public class CreateSavingCommandHandler : IRequestHandler<CreateSavingCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ISavingRepository _savingRepository;
        private readonly ILogger<CreateSavingCommand> _logger;

        public CreateSavingCommandHandler(IMapper mapper, ISavingRepository savingRepository, ILogger<CreateSavingCommand> logger)
        {
            _mapper = mapper;
            _savingRepository = savingRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateSavingCommand request, CancellationToken cancellationToken)
        {
            var saving = await _savingRepository.GetByUserId(request.UserId);
            
            if (saving != null)
            {
                _logger.LogWarning("User can has only one TotalSaving.");
                return Guid.Empty;
            }
            else
            {
                var addSaving = _mapper.Map<Saving>(request); 
                addSaving = await _savingRepository.AddAsync(addSaving);

                return addSaving.SavingId;
            }
        }
    }
}
