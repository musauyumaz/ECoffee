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
                .NotNull().WithMessage("Lütfen ürün açıklamasını boş geçmeyiniz.")
                .MinimumLength(10)
                .MaximumLength(500).WithMessage("Açıklama metnini 10 ile 500 karakter arasında giriniz.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Lütfen ürün fiyatını 0'dan büyük giriniz.");

            RuleFor(p=>p.UnitsInStock)
                .GreaterThan(0).WithMessage("Lütfen stok miktarını sıfırdan büyük yapınız.");

            RuleForEach(p=>p.CategoryIds)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen Id'yi boş geçmeyiniz.")
                .WithMessage("Lütfen Id sıfırdan büyük olsun.");

        }
    }
}
