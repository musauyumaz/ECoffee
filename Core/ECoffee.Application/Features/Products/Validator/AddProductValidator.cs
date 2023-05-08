using ECoffee.Application.Features.Products.Commands.Add;
using FluentValidation;

namespace ECoffee.Application.Features.Products.Validator
{
    public class AddProductValidator : AbstractValidator<AddProductCommandRequest>
    {
        public AddProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen açıklamayı boş geçmeyiniz.")
                .MinimumLength(10)
                .MaximumLength(500).WithMessage("Açıklama 10 ile 500 karakter arasında olmalıdır");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

            RuleFor(p=>p.UnitsInStock)
                .GreaterThanOrEqualTo(0).WithMessage("Stok miktarı sıfırdan küçük olamaz.");

            RuleForEach(p=>p.CategoryIds)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen Id'yi boş geçmeyiniz")
                .GreaterThan(0).WithMessage("Lütfen Id sıfırdan büyük olsun");
        }
    }
}
