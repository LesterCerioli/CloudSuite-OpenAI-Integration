using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.RetryPolicies
{
    public class CreateRetryPolicyCommandValidation : AbstractValidator<CreateRetryPolicyCommand>
    {
        public CreateRetryPolicyCommandValidation()
        {
            RuleFor(a => a.MaxRetryAttempts)
                .NotEmpty()
                .WithMessage("O campo MaxRetryAttempts é obrigatório")
                .NotNull()
                .WithMessage("O campo MaxRetryAttempts não pode ser nulo.");

            RuleFor(a => a.RetryDelayMilliseconds)
                .NotEmpty()
                .WithMessage("O campo Milliseconds é obrigatório")
                .NotNull()
                .WithMessage("O campo Milliseconds não pode ser nulo.");
        }
    }
}
