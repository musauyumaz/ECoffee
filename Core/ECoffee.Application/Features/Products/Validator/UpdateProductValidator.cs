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

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(30)
                .MinimumLength(3)
                    .WithMessage("Lütfen ürün adını 3 ile 30 karakter arasında giriniz.");

            RuleFor(p => p.Description)
                .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen kategori açıklamasını boş geçmeyiniz.")
               .MaximumLength(150)
               .MinimumLength(0)
                   .WithMessage("Lütfen kategori açıklamasını 0 ile 150 karakter arasında giriniz.");

            RuleFor(p=>p.Price)
                .GreaterThan(0).WithMessage("Lütfen ürün fiyatını 0'dan büyük giriniz.");

            RuleFor(p=>p.UnitsInStock)
                .GreaterThanOrEqualTo(0).WithMessage("Lütfen stok miktarını değiştiriniz ve sıfırdan büyük yapınız.");

            RuleForEach(p => p.CategoryIds)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen Id'yi boş geçmeyiniz.")
                .GreaterThanOrEqualTo(0).WithMessage("Lütfen Id'yi değiştiriniz ve sıfırdan büyük yapınız.");
        }
    }
}
