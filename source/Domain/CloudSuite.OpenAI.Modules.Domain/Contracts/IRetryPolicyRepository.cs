using CloudSuite.OpenAI.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.OpenAI.Modules.Domain.Contracts
{
    public interface IRetryPolicyRepository
    {
        Task<RetryPolicy> GetByMaxRetryAttempts(int maxRetryAttempts);

        Task<RetryPolicy> GetByRetryDelayMilliseconds(int retryDelayMilliseconds);

        Task<IEnumerable<RetryPolicy>> GetAll();    

        Task Add(RetryPolicy policy);

        void Update(RetryPolicy policy);

        void Remove(RetryPolicy policy);
    }
}
