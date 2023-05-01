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
        }
    }
}
