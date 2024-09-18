using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Requests
{
    public class CheckPromptExistsByTextRequest : IRequest<CheckPromptExistsByTextResponse>
    {
        public Guid Id { get; private set; }

        public string? Text { get; set; }

        public CheckPromptExistsByTextRequest(string? text)
        {
            Id = Guid.NewGuid();
            Text = text;
        }
    }
}
