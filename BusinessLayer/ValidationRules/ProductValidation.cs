using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Description).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Price).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
