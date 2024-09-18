using CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.ErrorLogs
{
    public class CheckErrorLogExistsByErrorMessageRequestValidation : AbstractValidator<CheckErrorLogExistsByErrorMessageRequest>
    {
        public CheckErrorLogExistsByErrorMessageRequestValidation()
        {
            RuleFor(a => a.ErrorMessage)
                .NotEmpty()
                .WithMessage("O campo ErrorMessage é obrigatório")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo ErrorMessage deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo ErrorMessage não pode ser nulo.");
        }
    }
}
