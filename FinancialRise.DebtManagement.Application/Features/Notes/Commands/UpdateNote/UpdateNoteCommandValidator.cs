using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(c => c.TypeOfNote).IsInEnum();

            RuleFor(c => c.Content)
                .MaximumLength(500)
                .WithMessage("Text can't be longer than 500 characters.");
        }
    }
}
