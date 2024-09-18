using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromptEntity = CloudSuite.OpenAI.Modules.Domain.Models.Prompt;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.Prompts
{
    public class CreatePromptCommand : IRequest<CreatePromptResponse>
    {
        public Guid Id { get; private set; }

        public string? Text { get; set; }

        public int? MaxTokens { get; set; }

        public DateTime? Timestamp { get; set; }

        public PromptEntity GetEntity()
        {
            return new PromptEntity(
                this.Text,
                this.MaxTokens,
                this.Timestamp);
        }
    }
}
