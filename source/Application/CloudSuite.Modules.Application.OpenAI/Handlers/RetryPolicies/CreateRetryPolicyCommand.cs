using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetryPoliceEntity = CloudSuite.OpenAI.Modules.Domain.Models.RetryPolicy;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies
{
    public class CreateRetryPolicyCommand : IRequest<CreateRetryPolicyResponse>
    {
        public Guid Id { get; private set; }

        public int? MaxRetryAttempts { get; set; }

        public int? RetryDelayMilliseconds { get; set; }

        public RetryPoliceEntity GetEntity()
        {
            return new RetryPoliceEntity(
                this.MaxRetryAttempts,
                this.RetryDelayMilliseconds);
        }
    }
}
