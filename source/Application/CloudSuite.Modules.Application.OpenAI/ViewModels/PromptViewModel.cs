using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.ViewModels
{
    public class PromptViewModel
    {
        [Key]

        public Guid Id { get; private set; }

        [DisplayName("Text")]
        public string? Text { get; set; }

        [DisplayName("MaxTokens")]
        public int? MaxTokens { get; set; }

        [DisplayName("Timestamp")]
        public DateTime? Timestamp { get; set; }
    }
}
