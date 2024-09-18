using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.ViewModels
{
    public class ErrorLogViewModel
    {
        [Key]

        public Guid Id { get; private set; }

        [DisplayName("Attempt")]
         public int? Attempt { get; set; }

        [DisplayName("Prompt")]
        public string? Prompt { get; set; }

        [DisplayName("ErrorMessage")]
        public string? ErrorMessage { get; set; }

        [DisplayName("Timestamp")]
        public DateTime? Timestamp { get; set; }
    }
}
