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
    public class CheckErrorLogExistsByErrorMessageHandler : IRequestHandler<CheckErrorLogExistsByErrorMessageRequest, CheckErrorLogExistsByErrorMessageResponse>
    {
        private IErrorLogRepository _errorLogRepository;
        private readonly ILogger<CheckErrorLogExistsByErrorMessageHandler> _logger;

        public async Task<CheckErrorLogExistsByErrorMessageResponse> Handle(CheckErrorLogExistsByErrorMessageRequest request, CancellationToken cancelation)
        {
            _logger.LogInformation($"CheckMediaExistsByErrorMessageRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckErrorLogExistsByErrorMessageRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var errorMessage = await _errorLogRepository.GetByErrorMessage(request.ErrorMessage);

                    if (errorMessage != null)
                    {
                        return await Task.FromResult(new CheckErrorLogExistsByErrorMessageResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckErrorLogExistsByErrorMessageResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckErrorLogExistsByErrorMessageResponse(request.Id, false, validationResult));
        }
    }
}
