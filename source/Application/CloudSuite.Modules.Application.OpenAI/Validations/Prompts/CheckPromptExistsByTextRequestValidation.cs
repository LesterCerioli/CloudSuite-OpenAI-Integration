using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.Prompts
{
    public class CheckPromptExistsByTextRequestValidation : AbstractValidator<CheckPromptExistsByTextRequest>
    {
        public CheckPromptExistsByTextRequestValidation() 
        {
            RuleFor(a => a.Text)
               .NotEmpty()
               .WithMessage("O campo Text é obrigatório")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo Text deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo Text não pode ser nulo.");
        }
    }
}
