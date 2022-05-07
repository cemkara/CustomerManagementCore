using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EmployeTypeValidation : AbstractValidator<EmployeType>
    {
        public EmployeTypeValidation()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
