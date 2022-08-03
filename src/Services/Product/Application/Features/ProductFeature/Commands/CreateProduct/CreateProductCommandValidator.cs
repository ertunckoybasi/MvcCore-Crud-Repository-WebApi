using FluentValidation;

namespace ProductSrv.Application.Features.ProductFeature.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();
        
        RuleFor(v => v.Description)
           .MaximumLength(350)
           .NotEmpty();

        RuleFor(v => v.Price)
            .GreaterThan(0);
    }
}
