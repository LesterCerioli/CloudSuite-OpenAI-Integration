using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.OpenAI.Modules.Domain.Models
{

    // Logs the errors that occur during API processing
    public class ErrorLog : Entity, IAggregateRoot
    {
        public ErrorLog(int? attempt, string? prompt, string? errorMessage, DateTime? timestamp)
        {
            Attempt = attempt;
            Prompt = prompt;
            ErrorMessage = errorMessage;
            Timestamp = DateTime.Now;

        }

        public int? Attempt { get; private set; }

        public string? Prompt { get; private set; }

        public string? ErrorMessage { get; private set; }

        public DateTime? Timestamp { get; private set; }
    }
}
