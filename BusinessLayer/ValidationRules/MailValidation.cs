using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MailValidation : AbstractValidator<Mail>
    {
        public MailValidation()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
