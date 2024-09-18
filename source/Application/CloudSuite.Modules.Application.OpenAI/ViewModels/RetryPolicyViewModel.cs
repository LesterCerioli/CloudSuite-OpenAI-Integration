using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.ViewModels
{
    public class RetryPolicyViewModel
    {
        [Key]

        public Guid Id { get; private set; }

        [DisplayName("MaxRetryAttempts")]
        public int? MaxRetryAttempts { get; set; }

        [DisplayName("RetryDelayMilliseconds")]
        public int? RetryDelayMilliseconds { get; set; }
    }
}
