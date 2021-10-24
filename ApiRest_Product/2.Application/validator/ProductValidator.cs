using ApiRest_Product._2.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Product._2.Application.validator
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {

            RuleFor(x => x.cProductName).NotEmpty().Length(1,9999999)
                .WithMessage("Ingrese un nombre");

            RuleFor(x => x.nPrice).NotEmpty().GreaterThan(0)
                .WithMessage("Ingrese un precio");

            RuleFor(x => x.nStock).NotEmpty().GreaterThan(0)
                .WithMessage("Ingrese una cantidad");
        }
    }
}
