using ECoffee.Application.Features.Customers.Commands.Delete;
using FluentValidation;

namespace ECoffee.Application.Features.Customers.Validators
{
    public class DeleteCustomerValidator:AbstractValidator<DeleteCustomerCommandRequest>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .NotNull().WithMessage("Lütfen müşteri id'sini boş geçmeyiniz.");
        }
    }
}
