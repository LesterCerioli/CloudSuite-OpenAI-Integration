using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.RetryPolicies
{
    public class CheckRetryPolicyByMaxRetryAttemptsRequestValidation : AbstractValidator<CheckRetryPolicyExistsByMaxRetryAttemptsRequest>
    {
        public CheckRetryPolicyByMaxRetryAttemptsRequestValidation()
        {
            RuleFor(a => a.MaxRetryAttempts)
                .NotEmpty()
                .WithMessage("O campo MaxRetryAttempts é obrigatório")
                .NotNull()
                .WithMessage("O campo MaxRetryAttempts não pode ser nulo.");
        }
    }
}
