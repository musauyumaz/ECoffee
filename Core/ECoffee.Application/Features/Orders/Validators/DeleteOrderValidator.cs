using ECoffee.Application.Features.Orders.Commands.Delete;
using FluentValidation;

namespace ECoffee.Application.Features.Orders.Validators
{
    public class DeleteOrderValidator:AbstractValidator<DeleteOrderCommandRequest>
    {
        public DeleteOrderValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen Id'yi boş geçmeyiniz");
        }
    }
}
