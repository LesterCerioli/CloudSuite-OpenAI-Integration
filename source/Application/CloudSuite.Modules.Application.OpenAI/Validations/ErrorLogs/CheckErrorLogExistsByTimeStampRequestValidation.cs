using CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.ErrorLogs
{
    public class CheckErrorLogExistsByTimeStampRequestValidation : AbstractValidator<CheckErrorLogExistsByTimeStampRequest>
    {
        public CheckErrorLogExistsByTimeStampRequestValidation() 
        {
            RuleFor(a => a.Timestamp)
                .NotEmpty()
                .WithMessage("O campo TimeStamp é obrigatório")
                .NotNull()
                .WithMessage("O campo TimeStamp não pode ser nulo.");
        }
    }
}
