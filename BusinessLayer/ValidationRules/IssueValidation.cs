using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class IssueValidation : AbstractValidator<Issue>
    {
        public IssueValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Description).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.PaymentStatusId).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
