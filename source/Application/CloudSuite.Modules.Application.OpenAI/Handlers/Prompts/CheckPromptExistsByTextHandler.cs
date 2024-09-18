using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Requests;
using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses;
using CloudSuite.Modules.Application.OpenAI.Validations.Prompts;
using CloudSuite.OpenAI.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.Prompts
{
    public class CheckPromptExistsByTextHandler : IRequestHandler<CheckPromptExistsByTextRequest, CheckPromptExistsByTextResponse>
    {
        private IPromptRepository _promptRepository;
        private readonly ILogger<CheckPromptExistsByTextHandler> _logger;

        public async Task<CheckPromptExistsByTextResponse> Handle(CheckPromptExistsByTextRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByTextRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPromptExistsByTextRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var text = await _promptRepository.GetByText(request.Text);

                    if (text != null)
                    {
                        return await Task.FromResult(new CheckPromptExistsByTextResponse(request.Id, true, validationResult));

                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPromptExistsByTextResponse(request.Id, "Failed to process the request"));
                }
            }
            return await Task.FromResult(new CheckPromptExistsByTextResponse(request.Id, false, validationResult));

        }
    }
}
