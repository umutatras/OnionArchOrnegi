using FluentValidation;
using OnionArchOrnegi.Application.Product.Commands.Add;

namespace InvoiceBackend.Application.Invoice.Commands.Add;

public sealed class ProductCommandValidator : AbstractValidator<ProductAddCommand>
{
    public ProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is not null");
    }
}
