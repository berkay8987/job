using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MusteriSiparisUygulamasi.Models.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() 
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Customer Name Can't Be Null!");
            RuleFor(x => x.Name).Length(3, 10).WithMessage("The Length Of The Name Should Be Between 3-10");
            RuleFor(x => x.Phone).Length(3, 10).WithMessage("The Length Of The Phone Should Be Between 3-10");
        }
    }
}
