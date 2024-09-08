using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.OpenAI.Modules.Domain.Models
{

    // Defines the retry policy used when making requests
    public class RetryPolicy : Entity, IAggregateRoot
    {
        public RetryPolicy(int? maxRetryAttempts, int? retryDelayMilliseconds)
        {
            MaxRetryAttempts = maxRetryAttempts;
            RetryDelayMilliseconds = retryDelayMilliseconds;
        }

        public int? MaxRetryAttempts { get; private set; }

        public int? RetryDelayMilliseconds { get; private set; }

    }
}
