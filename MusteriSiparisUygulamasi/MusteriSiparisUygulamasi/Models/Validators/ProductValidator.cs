using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MusteriSiparisUygulamasi.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Product Name Can't Be Null!");
            RuleFor(x => x.Name).Length(3, 10).WithMessage("The Length Of The Name Should Be Between 3 - 10");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(99).WithMessage("Minimum Price is 99");
            RuleFor(x => x.Price).LessThanOrEqualTo(29999).WithMessage("Maximum Price is 29999");
        }
    }
}
