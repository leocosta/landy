using FluentValidation;

namespace Landy.Services.Offer.Core.Commands.Validators
{
    public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
    {
        public CreateOfferCommandValidator()
        {
            RuleFor(m => m.Offer).NotNull();
            RuleFor(m => m.Offer.Title).NotEmpty();
            RuleFor(m => m.Offer.Description).NotEmpty();
            RuleFor(m => m.Offer.AvailableUnits).GreaterThan(0);

            RuleFor(m => m.Offer.Images)
                .Must(i => i.Count > 0)
                .When(i => i.Offer.Images != null);

            RuleFor(m => m.Offer.Amount).NotNull();
            RuleFor(m => m.Offer.Amount.Currency)
                .NotEmpty()
                .When(i => i.Offer.Amount != null);

            RuleFor(m => m.Offer.Amount.Value)
                .GreaterThan(0)
                .When(i => i.Offer.Amount != null);
        }
    }
}