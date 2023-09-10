using ECoffee.Application.Features.Categories.Commands.Delete;
using FluentValidation;

namespace ECoffee.Application.Features.Categories.Validators
{
    public class DeleteCategoryValidator:AbstractValidator<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryValidator() {
            RuleFor(c => c.Id).NotEmpty()
                .NotNull().WithMessage("Lütfen kategori id'sini boş geçmeyiniz.");
                //.WithMessage("Lütfen kategori id'sini 0'dan büyük giriniz."); bunu kaldıralım.
        }
    }
}
