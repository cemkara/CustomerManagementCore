using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EmployeValidation : AbstractValidator<Employe>
    {
        public EmployeValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Username).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Password).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
