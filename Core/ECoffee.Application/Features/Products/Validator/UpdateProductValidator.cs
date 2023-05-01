using ECoffee.Application.Features.Products.Commands.Update;
using FluentValidation;

namespace ECoffee.Application.Features.Products.Validator
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Id)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen Id'yi boş geçmeyiniz")
              .GreaterThan(0).WithMessage("Lütfen Id sıfırdan büyük olsun");
        }
    }
}
