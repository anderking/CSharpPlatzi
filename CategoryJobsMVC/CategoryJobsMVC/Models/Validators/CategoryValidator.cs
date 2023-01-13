using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CategoryJobsMVC.Models.Validators
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Campo requerido");
            RuleFor(x => x.Description).NotNull().WithMessage("Campo requerido");
        }
    }
}
