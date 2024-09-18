using CloudSuite.Modules.Application.OpenAI.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Responses
{
    public class CheckRetryPolicyExistsByMaxRetryAttemptsResponse : Response
    {
        public Guid RequestId { get; private set; }

        public bool Exists { get; set; }

        public CheckRetryPolicyExistsByMaxRetryAttemptsResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckRetryPolicyExistsByMaxRetryAttemptsResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falseValidation);
            
        }
    }
}
