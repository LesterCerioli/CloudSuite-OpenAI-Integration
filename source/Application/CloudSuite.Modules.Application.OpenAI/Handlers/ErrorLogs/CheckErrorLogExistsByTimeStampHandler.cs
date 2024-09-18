using CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Requests;
using CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs.Responses;
using CloudSuite.Modules.Application.OpenAI.Validations.ErrorLogs;
using CloudSuite.OpenAI.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.ErrorLogs
{
    public class CheckErrorLogExistsByTimeStampHandler : IRequestHandler<CheckErrorLogExistsByTimeStampRequest, CheckErrorLogExistsByTimeStampResponse>
    {
        private IErrorLogRepository _errorLogRepository;
        private readonly ILogger<CheckErrorLogExistsByTimeStampHandler> _logger;


        public async Task<CheckErrorLogExistsByTimeStampResponse> Handle(CheckErrorLogExistsByTimeStampRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByTimeStampRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckErrorLogExistsByTimeStampRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var adressLine = await _errorLogRepository.GetByTimestamp(request.Timestamp);

                    if (adressLine != null)
                    {
                        return await Task.FromResult(new CheckErrorLogExistsByTimeStampResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckErrorLogExistsByTimeStampResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckErrorLogExistsByTimeStampResponse(request.Id, false, validationResult));
        }
    }
}
