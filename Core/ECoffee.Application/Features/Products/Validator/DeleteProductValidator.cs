using ECoffee.Application.Features.Products.Commands.Delete;
using FluentValidation;

namespace ECoffee.Application.Features.Products.Validator
{
    public class DeleteProductValidator:AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty()
               .NotNull().WithMessage("Lütfen Id'yi boş geçmeyiniz")
               .GreaterThan(0).WithMessage("Lütfen Id sıfırdan büyük olsun");
        }
    }
}
