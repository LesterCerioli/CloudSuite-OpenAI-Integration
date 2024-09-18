using CloudSuite.OpenAI.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.OpenAI.Modules.Domain.Contracts
{
    public interface IErrorLogRepository
    {
        Task<ErrorLog> GetByErrorMessage(string errorMessage);

        Task<ErrorLog> GetByTimestamp(DateTime? timestamp);

        Task<IEnumerable<ErrorLog>> GetAll();

        Task Add(ErrorLog error);

        void Update(ErrorLog error);

        void Remove(ErrorLog error);
    }
}
