using ECoffee.Application.Features.Products.Queries.GetById;
using FluentValidation;

namespace ECoffee.Application.Features.Products.Validator
{
    public class GetByIdProductValidator:AbstractValidator<GetByIdProductQueryRequest>
    {
        public GetByIdProductValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty()
               .NotNull().WithMessage("Lütfen Id alanını boş geçmeyiniz.");
        }
    }
}
