using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Validations.RetryPolicies
{
    public class CheckRetryPolicyByRetryDelayMillisecondsRequestValidation : AbstractValidator<CheckRetryPolicyExistsByRetryDelayMillisecondsResquest>
    {
        public CheckRetryPolicyByRetryDelayMillisecondsRequestValidation()
        {
            RuleFor(a => a.RetryDelayMilliseconds)
                .NotEmpty()
                .WithMessage("O campo Milliseconds é obrigatório")
                .NotNull()
                .WithMessage("O campo Milliseconds não pode ser nulo.");
        }
    }
}
