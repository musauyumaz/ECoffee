using ECoffee.Application.Features.Categories.Queries.GetById;
using FluentValidation;

namespace ECoffee.Application.Features.Categories.Validators
{
    public class GetByIdCategoryValidator:AbstractValidator<GetByIdCategoryQueryRequest>
    {
        public GetByIdCategoryValidator()
        {
             RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen kategori id'sini boş geçmeyiniz.")
                .GreaterThan(0)
                    .WithMessage("Lütfen kategori id'sini 0'dan büyük giriniz.");
        }
    }
}
