using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<CreateContactCommandHandler> _logger;

        public CreateContactCommandHandler(IMapper mapper, IContactRepository contactRepository, ILogger<CreateContactCommandHandler> logger)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContactCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count>0)
            {
                var validResult = validationResult.ToString();
                _logger.LogError(validResult);
                throw new ValidationException(validResult);
            }

            var contact = _mapper.Map<Contact>(request);
            contact = await _contactRepository.AddAsync(contact);

            return contact.ContactId;
        }
    }
}
