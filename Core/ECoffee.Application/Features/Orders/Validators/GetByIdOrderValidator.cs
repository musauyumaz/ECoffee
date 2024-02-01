using ECoffee.Application.Features.Orders.Queries.GetById;
using FluentValidation;

namespace ECoffee.Application.Features.Orders.Validators
{
    public class GetByIdOrderValidator:AbstractValidator<GetByIdOrderQueryRequest>
    {
        public GetByIdOrderValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen Id'yi boş geçmeyiniz");
        }
    }
}
