﻿using ECoffee.Application.Features.Products.Commands.Delete;
using FluentValidation;

namespace ECoffee.Application.Features.Products.Validator
{
    public class DeleteProductValidator:AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty()
               .NotNull().WithMessage("Lütfen Id alanını boş geçmeyiniz.");
        }
    }
}
