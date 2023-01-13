using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CategoryJobsMVC.Models.Validators
{
    public class JobValidator: AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.IdCategory).NotNull().WithMessage("Campo requerido");
            RuleFor(x => x.Name).NotNull().WithMessage("Campo requerido");
            RuleFor(x => x.Description).NotNull().WithMessage("Campo requerido");
            RuleFor(x => x.Priority).NotNull().WithMessage("Campo requerido");
        }
    }
}
