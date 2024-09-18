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
    public class CheckRetryPolicyExistsByRetryDelayMillisecondsHandler : IRequestHandler<CheckRetryPolicyExistsByRetryDelayMillisecondsResquest, CheckRetryPolicyExistsByRetryDelayMillisecondsResponse>
    {
        private IRetryPolicyRepository _policyRepository;
        private readonly ILogger<CheckRetryPolicyExistsByRetryDelayMillisecondsHandler> _logger;

        public async Task<CheckRetryPolicyExistsByRetryDelayMillisecondsResponse> Handle(CheckRetryPolicyExistsByRetryDelayMillisecondsResquest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractExistsByRetryDelayMillisecondsRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckRetryPolicyByRetryDelayMillisecondsRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var retryDelayMilliseconds = await _policyRepository.GetByRetryDelayMilliseconds(request.RetryDelayMilliseconds);
                    if (retryDelayMilliseconds != null)
                    {
                        return await Task.FromResult(new CheckRetryPolicyExistsByRetryDelayMillisecondsResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckRetryPolicyExistsByRetryDelayMillisecondsResponse(request.Id, "Failed to process the request."));
                }

            }
            return await Task.FromResult(new CheckRetryPolicyExistsByRetryDelayMillisecondsResponse(request.Id, false, validationResult));
        }
    }
}
