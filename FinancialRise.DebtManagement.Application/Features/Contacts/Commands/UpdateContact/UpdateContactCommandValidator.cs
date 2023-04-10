using System.Text.RegularExpressions;
using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandValidator :AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(c => c.Email).EmailAddress();
        }
    }
}
