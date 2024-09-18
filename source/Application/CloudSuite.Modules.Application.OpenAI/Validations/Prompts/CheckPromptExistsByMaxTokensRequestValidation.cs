using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.Prompts
{
    public class CheckPromptExistsByMaxTokensRequestValidation : AbstractValidator<CheckPromptExistsByMaxTokensRequest>
    {
        public CheckPromptExistsByMaxTokensRequestValidation()
        {
            RuleFor(a => a.MaxTokens)
               .NotEmpty()
               .WithMessage("O campo MaxTokens é obrigatório")
               .NotNull()
               .WithMessage("O campo MaxTokens não pode ser nulo.");
        }
    }
}
