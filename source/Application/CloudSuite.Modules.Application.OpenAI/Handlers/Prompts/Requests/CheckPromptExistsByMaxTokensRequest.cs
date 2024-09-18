using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Requests
{
    public class CheckPromptExistsByMaxTokensRequest : IRequest<CheckPromptExistsByMaxTokensResponse>
    {
        public Guid Id { get; private set; }

        public int? MaxTokens { get; set; }

        public CheckPromptExistsByMaxTokensRequest(int? maxTokens)
        {
            Id = Guid.NewGuid();
            MaxTokens = maxTokens;
        }
    }
}
