
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(p=>p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please dont leave here blank")
                .MaximumLength(150).MinimumLength(3).WithMessage("Please enter the product name between 2-150 characters");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please dont leave here blank").Must(s => s > 0).WithMessage("Stock can not be negative!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please dont leave here blank").Must(s => s > 0).WithMessage("Price can not be negative!");
        }
    }
}
