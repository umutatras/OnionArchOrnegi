using FluentValidation;

namespace OnionArchOrnegi.Application.Product.Commands.Delete;

public class ProductDeleteCommandValidator : AbstractValidator<ProductDeleteCommand>
{
    public ProductDeleteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is not null");
    }
}
