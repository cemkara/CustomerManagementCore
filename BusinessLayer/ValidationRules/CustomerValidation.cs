using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
