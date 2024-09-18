using CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Requests
{
    public class CheckErrorLogExistsByErrorMessageRequest : IRequest<CheckErrorLogExistsByErrorMessageResponse>
    {
        public Guid Id { get; private set; }

        public string? ErrorMessage { get; set; }

        public CheckErrorLogExistsByErrorMessageRequest(string? errorMessage)
        {
            Id = Guid.NewGuid();
            ErrorMessage = errorMessage;
        }
    }
}
