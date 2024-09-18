using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Requests;
using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses;
using CloudSuite.OpenAI.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using CloudSuite.Modules.Application.OpenAI.Validations.Prompts;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.Prompts
{
    public class CheckPromptExistsByMaxTokensHandler : IRequestHandler<CheckPromptExistsByMaxTokensRequest, CheckPromptExistsByMaxTokensResponse>
    {
        private IPromptRepository _promptRepository;
        private readonly ILogger<CheckPromptExistsByMaxTokensHandler> _logger;


        public async Task<CheckPromptExistsByMaxTokensResponse> Handle(CheckPromptExistsByMaxTokensRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByMaxTokensRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPromptExistsByMaxTokensRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var maxTokens = await _promptRepository.GetByMaxTokens(request.MaxTokens);

                    if (maxTokens != null)
                    {
                        return await Task.FromResult(new CheckPromptExistsByMaxTokensResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPromptExistsByMaxTokensResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckPromptExistsByMaxTokensResponse(request.Id, false, validationResult));

        }
    }
}
