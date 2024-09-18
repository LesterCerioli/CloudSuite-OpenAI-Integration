using CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorLogEntity = CloudSuite.OpenAI.Modules.Domain.Models.ErrorLog;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs
{
    public class CreateErrorLogCommand : IRequest<CreateErrorLogResponse>
    {
        public Guid Id { get; private set; }

        public int? Attempt { get; set; }

        public string? Prompt { get; set; }

        public string? ErrorMessage { get; set; }

        public DateTime? Timestamp { get; set; }

        public ErrorLogEntity GetEntity()
        {
            return new ErrorLogEntity(
                this.Attempt,
                this.Prompt,
                this.ErrorMessage,
                this.Timestamp);
        }
    }
}
