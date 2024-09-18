using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses;
using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Requests;
using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Responses;
using CloudSuite.Modules.Application.OpenAI.Validations.RetryPolicies;
using CloudSuite.OpenAI.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies
{
    public class CheckRetryPolicyExistsByMaxRetryAttemptsHandler : IRequestHandler<CheckRetryPolicyExistsByMaxRetryAttemptsRequest, CheckRetryPolicyExistsByMaxRetryAttemptsResponse>
    {
        private IRetryPolicyRepository _policyRepository;
        private readonly ILogger<CheckRetryPolicyExistsByMaxRetryAttemptsHandler> _logger;

        public async Task<CheckRetryPolicyExistsByMaxRetryAttemptsResponse> Handle(CheckRetryPolicyExistsByMaxRetryAttemptsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByMaxRetryAttemptsRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckRetryPolicyByMaxRetryAttemptsRequestValidation().Validate( request );

            if (validationResult.IsValid)
            {
                try
                {
                    var maxRetryAttempts = await _policyRepository.GetByMaxRetryAttempts(request.MaxRetryAttempts);
                    if (maxRetryAttempts != null)
                    {
                        return await Task.FromResult(new CheckRetryPolicyExistsByMaxRetryAttemptsResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckRetryPolicyExistsByMaxRetryAttemptsResponse(request.Id, "Failed to process the request."));
                }

            }
            return await Task.FromResult(new CheckRetryPolicyExistsByMaxRetryAttemptsResponse(request.Id, false, validationResult));
        }
    }
}