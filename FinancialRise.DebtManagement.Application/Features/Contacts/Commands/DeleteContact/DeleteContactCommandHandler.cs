using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Application.Contracts.Persistence;
using FinancialRise.DebtManagement.Domain.Entities;
using MediatR;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandHandler :IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactCommandHandler( IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contactToDelete = await _contactRepository.GetByIdAsync(request.ContactId);

            if (contactToDelete == null || !contactToDelete.UserId.Equals(request.UserId))
                throw new Exception($"{nameof(Contact)} with the id: {request.ContactId} not found");

            await _contactRepository.DeleteAsync(contactToDelete);

            return Unit.Value;
        }
    }
}
