using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Requests
{
    public class CheckRetryPolicyExistsByRetryDelayMillisecondsResquest : IRequest<CheckRetryPolicyExistsByRetryDelayMillisecondsResponse>
    {
        public Guid Id { get; private set; }

        public int? RetryDelayMilliseconds { get; set; }

        public CheckRetryPolicyExistsByRetryDelayMillisecondsResquest(int? retryDelayMilliseconds)
        {
            Id = Guid.NewGuid();
            RetryDelayMilliseconds = retryDelayMilliseconds;
        }
    }
}
