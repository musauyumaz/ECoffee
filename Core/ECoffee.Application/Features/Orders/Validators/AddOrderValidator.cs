using ECoffee.Application.Features.Orders.Commands.Add;
using FluentValidation;

namespace ECoffee.Application.Features.Orders.Validators
{
    public class AddOrderValidator:AbstractValidator<AddOrderCommandRequest>
    {
        public AddOrderValidator()
        {
            RuleFor(o => o.Note)
                .NotEmpty().WithMessage("Boş Geçilemez")
                .NotNull()
                .MinimumLength(10).MaximumLength(150)
                .WithMessage("Not metni 10 karakter ile 150 karakter arasında olmalıdır");

            RuleForEach(o => o.ProductIds)
                .NotEmpty().WithMessage("Boş Geçilemez")
                .NotNull()
                .GreaterThan(0).WithMessage("ID'ler 0'dan Büyük Olmalıdır");

            RuleFor(o=>o.CustomerId)
                .NotEmpty().WithMessage("Boş Geçilemez")
                .NotNull()
                .GreaterThan(0).WithMessage("ID'ler 0'dan Büyük Olmalıdır");
        }
    }
}
