using ECoffee.Application.Features.Orders.Commands.Update;
using FluentValidation;

namespace ECoffee.Application.Features.Orders.Validators
{
    public class UpdateOrderValidator:AbstractValidator<UpdateOrderCommandRequest>
    {
        public UpdateOrderValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen Id'yi boş geçmeyiniz")
                .GreaterThan(0).WithMessage("Lütfen Id'yi sıfırdan büyük olsun");

            RuleFor(o => o.Note)
                .NotEmpty().WithMessage("Lütfen sipariş notunu boş geçmeyiniz")
                .NotNull()
                .MinimumLength(10).MaximumLength(150)
                .WithMessage("Lütfen sipariş notunu 10 ile 150 karakter arasında giriniz.");

            RuleForEach(o => o.ProductIds)
                .NotEmpty().WithMessage("Lütfen ürün Id'lerini boş geçmeyiniz.")
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("Lütfen ürün Id'lerini farklı ve sıfırdan büyük giriniz.");

            RuleFor(o => o.IsActive)
                .NotEmpty().WithMessage("Lütfen ürünün aktiflik durumunu doldurunuz.")
                .Must(x => x == false || x == true)
                .WithMessage("Lütfen sıfır veya 1 giriniz.");
        }
    }
}
