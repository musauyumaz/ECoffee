using ECoffee.Application.Features.Categories.Commands.Add;
using FluentValidation;

namespace ECoffee.Application.Features.Categories.Validators
{
    public class AddCategoryValidator:AbstractValidator<AddCategoryCommandRequest>
    {
        public AddCategoryValidator() {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen kategori adını boş geçmeyiniz.")
                .MaximumLength(30)
                .MinimumLength(3)
                    .WithMessage("Lütfen kategori adını 3 ile 30 karakter arasında giriniz.");

            RuleFor(c => c.Description)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen kategori açıklamasını boş geçmeyiniz.")
               .MaximumLength(150)
               .MinimumLength(0)
                   .WithMessage("Lütfen kategori açıklamasını 0 ile 150 karakter arasında giriniz.");

        }
    }
}
