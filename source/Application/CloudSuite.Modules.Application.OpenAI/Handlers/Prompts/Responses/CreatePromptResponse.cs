using CloudSuite.Modules.Application.OpenAI.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses
{
    public class CreatePromptResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreatePromptResponse(Guid requestId,ValidationResult result) 
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }

        }

        public CreatePromptResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            this.AddError(falseValidation);
        }
    }
}
