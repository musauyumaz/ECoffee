using ECoffee.Application.Features.Orders.Commands.Add;
using FluentValidation;

namespace ECoffee.Application.Features.Orders.Validators
{
    public class AddOrderValidator:AbstractValidator<AddOrderCommandRequest>
    {
        public AddOrderValidator()
        {
            RuleFor(o => o.Note)
                .NotEmpty().WithMessage("Lütfen sipariş notunu boş geçmeyiniz")
                .NotEmpty().WithMessage("Boş Geçilemez")
                 .NotNull()
                 .MinimumLength(10).MaximumLength(150)
                .WithMessage("Lütfen sipariş notunu 10 ile 150 karakter arasında giriniz.")
                           .WithMessage("Not metni 10 karakter ile 150 karakter arasında olmalıdır");

            RuleForEach(o => o.ProductIds)
                .NotEmpty().WithMessage("Lütfen ürün Id'lerini boş geçmeyiniz.")
                .NotEmpty().WithMessage("Boş Geçilemez")
                .NotNull()
                .GreaterThan(0).WithMessage("Lütfen ürün Id'lerini sıfırdan büyük giriniz.")
                            .GreaterThan(0).WithMessage("ID'ler 0'dan Büyük Olmalıdır");

            RuleFor(o => o.CustomerId)
                .NotEmpty().WithMessage("Lütfen kullanıcı Id'lerini boş geçmeyiniz.")
                .NotEmpty().WithMessage("Boş Geçilemez")
                .NotNull()
                .GreaterThan(0).WithMessage("Lütfen kullanıcı Id'lerini sıfırdan büyük giriniz.")
                            .GreaterThan(0).WithMessage("ID'ler 0'dan Büyük Olmalıdır");

            var sayi = 5;
        }
    }
}
