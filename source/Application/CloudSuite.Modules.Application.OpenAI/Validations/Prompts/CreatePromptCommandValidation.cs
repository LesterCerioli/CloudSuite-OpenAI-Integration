using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.Prompts
{
    public class CreatePromptCommandValidation : AbstractValidator<CreatePromptCommand>
    {
        public CreatePromptCommandValidation() 
        {
            RuleFor(a => a.Text)
                .NotEmpty()
                .WithMessage("O campo Text é obrigatório")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Text deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo Text não pode ser nulo.");

            RuleFor(a => a.MaxTokens)
                .NotEmpty()
                .WithMessage("O campo MaxTokens é obrigatório")
                .NotNull()
                .WithMessage("O campo MaxTokens não pode ser nulo.");
        }
    }
}
