using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.OpenAI.Modules.Domain.Models
{
    public class Prompt : Entity, IAggregateRoot
    {
        public Prompt(string? text, int? maxTokens, DateTime? timestamp)
        {
            Text = text;
            MaxTokens = maxTokens;
            Timestamp = DateTime.Now;
        }

        public string? Text { get; private set; }

        public int? MaxTokens { get; private set; }

        public DateTime? Timestamp { get; private set; }
    }
}
