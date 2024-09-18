using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Requests
{
    public class CheckRetryPolicyExistsByMaxRetryAttemptsRequest : IRequest<CheckRetryPolicyExistsByMaxRetryAttemptsResponse>
    {
        public Guid Id { get; private set; }

        public int? MaxRetryAttempts { get; set; }

        public CheckRetryPolicyExistsByMaxRetryAttemptsRequest(int? maxRetryAttempsts)
        {
            Id = Guid.NewGuid();
            MaxRetryAttempts = maxRetryAttempsts;
        }
    }
}
