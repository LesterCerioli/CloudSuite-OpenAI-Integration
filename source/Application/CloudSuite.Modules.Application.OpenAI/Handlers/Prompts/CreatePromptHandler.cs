using CloudSuite.Modules.Application.OpenAI.Handlers.Prompts.Responses;
using CloudSuite.Modules.Application.OpenAI.Validations.Prompts;
using CloudSuite.OpenAI.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.OpenAI.Handlers.Prompts
{
    public class CreatePromptHandler : IRequestHandler<CreatePromptCommand, CreatePromptResponse>
    {
        private readonly IPromptRepository _promptRepository;
        private readonly ILogger<CreatePromptHandler> _logger;

        public CreatePromptHandler(IPromptRepository promptRepository, ILogger<CreatePromptHandler> logger)
        {
            _promptRepository = promptRepository;
            _logger = logger;
        }

        public async Task<CreatePromptResponse> Handle(CreatePromptCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreatePromptCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreatePromptCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var promptText = await _promptRepository.GetByText(command.Text);
                    var promptMaxTokens = await _promptRepository.GetByMaxTokens(command.MaxTokens);

                    if (promptText != null && promptMaxTokens != null)
                    {
                        return await Task.FromResult(new CreatePromptResponse(command.Id, "Text and MaxTokens already registred"));

                    }
                    await _promptRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreatePromptResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreatePromptResponse(command.Id, "It`s not possible to process your solicitation."));

                }
            }

            return await Task.FromResult(new CreatePromptResponse(command.Id, validationResult));
        }
    }
}
