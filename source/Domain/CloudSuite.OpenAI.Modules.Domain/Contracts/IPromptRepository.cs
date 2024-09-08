using CloudSuite.OpenAI.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.OpenAI.Modules.Domain.Contracts
{
    public interface IPromptRepository
    {
        Task<Prompt> GetByText(string text);

        Task<Prompt> GetByMaxTokens(int maxTokens);

        Task Add(Prompt prompt);

        void Update(Prompt prompt);

        void Remove(Prompt prompt);
    }
}
