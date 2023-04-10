using FluentValidation;

namespace FinancialRise.DebtManagement.Application.Features.Frequencies.Commands.CreateFrequency
{
    public class CreateFrequencyCommandValidator :AbstractValidator<CreateFrequencyCommand>
    {
        public CreateFrequencyCommandValidator()
        {
            RuleFor(x => x.Unit).IsInEnum();
            RuleFor(x => x.Number).GreaterThanOrEqualTo(0);
        }
    }
}
