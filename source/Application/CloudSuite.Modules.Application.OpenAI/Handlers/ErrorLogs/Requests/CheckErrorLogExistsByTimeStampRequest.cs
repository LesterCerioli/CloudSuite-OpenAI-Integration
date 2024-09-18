using CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Requests
{
    public class CheckErrorLogExistsByTimeStampRequest : IRequest<CheckErrorLogExistsByTimeStampResponse>
    {
        public Guid Id { get; private set; }

        public DateTime? Timestamp { get; set; }

        public CheckErrorLogExistsByTimeStampRequest(DateTime? timeStamp)
        {
            Id = Guid.NewGuid();
            Timestamp = timeStamp;
        }
    }
}
