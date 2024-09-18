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
    public class CreateErrorLogHandler : IRequestHandler<CreateErrorLogCommand, CreateErrorLogResponse>
    {
        private readonly IErrorLogRepository _errorLogRepository;
        private readonly ILogger<CreateErrorLogHandler> _logger;

        public CreateErrorLogHandler(IErrorLogRepository errorLogRepository, ILogger<CreateErrorLogHandler> logger)
        {
            _errorLogRepository = errorLogRepository;
            _logger = logger;
        }

        public async Task<CreateErrorLogResponse> Handle(CreateErrorLogCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateErrorLogCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateErrorLogCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var errorLogErroMessage = await _errorLogRepository.GetByErrorMessage(command.ErrorMessage);
                    var erroLogTimeStamp = await _errorLogRepository.GetByTimestamp(command.Timestamp);

                    if (errorLogErroMessage != null && erroLogTimeStamp != null)
                    {
                        return await Task.FromResult(new CreateErrorLogResponse(command.Id, "ErrorMessage and TimeStamp already registered"));
                    }
                    await _errorLogRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateErrorLogResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateErrorLogResponse(command.Id, "It`s not possible to process your solicitation."));
                }
            }

            return await Task.FromResult(new CreateErrorLogResponse(command.Id, validationResult));
        }
    }
}
