using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using FluentValidation;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public UpdateContactCommandHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contactToUpdate = await _contactRepository.GetByIdAsync(request.ContactId);

            if (contactToUpdate == null || !contactToUpdate.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Contact)} with the id: {request.ContactId} not found");

            var validator = new UpdateContactCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult.ToString());

            _mapper.Map(request, contactToUpdate, typeof(UpdateContactCommand), typeof(Contact));

            await _contactRepository.UpdateAsync(contactToUpdate);

            return Unit.Value;
        }
    }
}
