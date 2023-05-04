using ECoffee.Application.Features.Customers.Queries.GetById;
using FluentValidation;

namespace ECoffee.Application.Features.Customers.Validators
{
    public class GetByIdCustomerValidator:AbstractValidator<GetByIdCustomerQueryRequest>
    {
        public GetByIdCustomerValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .NotNull().WithMessage("Lütfen müşteri id'sini boş geçmeyiniz.")
                .GreaterThan(0).WithMessage("Lütfen müşteri id'sini 0'dan büyük giriniz.");
        }
    }
}
