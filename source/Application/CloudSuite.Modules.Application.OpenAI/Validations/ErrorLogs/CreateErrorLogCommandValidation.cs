using CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.ErrorLogs
{
    public class CreateErrorLogCommandValidation : AbstractValidator<CreateErrorLogCommand>
    {
        public CreateErrorLogCommandValidation()
        {
            RuleFor(a => a.ErrorMessage)
                .NotEmpty()
                .WithMessage("O campo ErrorMessage é obrigatório")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo ErrorMessage deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo ErrorMessage não pode ser nulo.");

            RuleFor(a => a.Timestamp)
                .NotEmpty()
                .WithMessage("O campo TimeStamp é obrigatório")
                .NotNull()
                .WithMessage("O campo TimeStamp não pode ser nulo.");
        }
    }
}
