using CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies.Responses;
using CloudSuite.Modules.Application.OpenAI.Validations.RetryPolicies;
using CloudSuite.OpenAI.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.RetryPolicies
{
    public class CreateRetryPolicyHandler : IRequestHandler<CreateRetryPolicyCommand, CreateRetryPolicyResponse>
    {
        private readonly IRetryPolicyRepository _retryPolicyRepository;
        private readonly ILogger<CreateRetryPolicyHandler> _logger;

        public CreateRetryPolicyHandler(IRetryPolicyRepository retryPolicyRepository, ILogger<CreateRetryPolicyHandler> logger)
        {
            _retryPolicyRepository = retryPolicyRepository;
            _logger = logger;
        }

        public async Task<CreateRetryPolicyResponse> Handle(CreateRetryPolicyCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateRetryPolicyCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateRetryPolicyCommandValidation().Validate( command );

            if (validationResult.IsValid)
            {
                try
                {
                    var maxRetryAttempts = await _retryPolicyRepository.GetByMaxRetryAttempts(command.MaxRetryAttempts);
                    var retryDelayMilliseconds = await _retryPolicyRepository.GetByRetryDelayMilliseconds(command.RetryDelayMilliseconds);

                    if (maxRetryAttempts != null && retryDelayMilliseconds != null)
                    {
                        return await Task.FromResult(new CreateRetryPolicyResponse(command.Id, "MaxRetryAttempts and RetryDelayMilliseconds already registred"));

                    }
                    await _retryPolicyRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateRetryPolicyResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message );
                    return await Task.FromResult(new CreateRetryPolicyResponse(command.Id, "It`s not possible to process your solicitation."));

                }

            }
            return await Task.FromResult(new CreateRetryPolicyResponse(command.Id,validationResult));
        }
    }
}
