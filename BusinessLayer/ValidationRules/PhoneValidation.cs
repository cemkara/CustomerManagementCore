using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PhoneValidation : AbstractValidator<Phone>
    {
        public PhoneValidation()
        {
            RuleFor(x => x.Number).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
