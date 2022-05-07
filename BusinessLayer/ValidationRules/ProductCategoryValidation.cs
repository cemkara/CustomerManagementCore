using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductCategoryValidation : AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
