using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.UpdateFrequency
{
    public class UpdateFrequencyCommandValidator : AbstractValidator<UpdateFrequencyCommand>
    {
        public UpdateFrequencyCommandValidator()
        {
            RuleFor(x => x.Unit).IsInEnum();
            RuleFor(x => x.Number).GreaterThanOrEqualTo(0);
        }
    }
}
