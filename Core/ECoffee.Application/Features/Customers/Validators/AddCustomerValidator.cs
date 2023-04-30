using ECoffee.Application.Features.Customers.Commands.Add;
using FluentValidation;

namespace ECoffee.Application.Features.Customers.Validators
{
    public class AddCustomerValidator :AbstractValidator<AddCustomerCommandRequest>
    {
        public AddCustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen müşteri adını boş geçmeyiniz.")
                .MaximumLength(30)
                .MinimumLength(3)
                    .WithMessage("Lütfen müşteri adını 5 ile 150 karakter arasında giriniz.");

            RuleFor(c => c.Surname)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen müşteri soyadını boş geçmeyiniz.")
               .MaximumLength(30)
               .MinimumLength(3)
                   .WithMessage("Lütfen müşteri soyadını 5 ile 150 karakter arasında giriniz.");

            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull().WithMessage("Email boş geçilemez.")
                .MinimumLength(15)
                .MaximumLength(100).WithMessage("Lütfen müşteri email'ini 15 ile 100 karakter arasında giriniz.");


        }
    }
}
