using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(c => c.TypeOfNote).IsInEnum();

            RuleFor(c => c.UserId)
                .NotNull()
                .WithMessage("Note has to belong to a particular user.");

            RuleFor(c => c.Content)
                .MaximumLength(500)
                .WithMessage("Text can't be longer than 500 characters.");
        }
    }
}
