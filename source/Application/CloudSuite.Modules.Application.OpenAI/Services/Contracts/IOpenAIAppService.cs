using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Services.Contracts
{
    public interface IOpenAIAppService
    {
        Task<string> GenerateCompletionAsync(string prompt);
    }
}
