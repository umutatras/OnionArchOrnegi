using FluentValidation;

namespace OnionArchOrnegi.Application.Product.Commands.Update;

public class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
{
    public ProductUpdateCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is not null");
    }
}
