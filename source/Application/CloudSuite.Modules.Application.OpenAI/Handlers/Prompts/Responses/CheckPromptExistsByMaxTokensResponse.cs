﻿using CloudSuite.Modules.Application.OpenAI.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses
{
    public class CheckPromptExistsByMaxTokensResponse : Response
    {
        public Guid RequestId { get; private set; }

        public bool Exists { get; set; }

        public CheckPromptExistsByMaxTokensResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckPromptExistsByMaxTokensResponse(Guid requestId, string falseValidation)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falseValidation);
        }
    }
}
