﻿using CloudSuite.Modules.Application.OpenAI.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CloudSuite.Modules.Application.OpenAI.Services.Implementatiosn
{
    public class OpenAIAppService : IOpenAIAppService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiKey;
        private readonly ILogger<OpenAIAppService> _logger;
        private readonly string? ApiUrl;
        private readonly int MaxRetryAttempts;
        private readonly int RetryDelayMilliseconds;

        public OpenAIAppService(HttpClient httpClient, IConfiguration configuration, ILogger<OpenAIAppService> logger)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenAI:ApiKey"];  // Chave de API armazenada no appsettings.json
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            _logger = logger;

        }


        public async Task<string> GenerateCompletionAsync(string prompt)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                prompt = prompt,
                max_tokens = 100
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            int attempt = 0;
            bool success = false;
            string responseContent = string.Empty;

            //Start re-processing looping
            while (attempt < MaxRetryAttempts && !success)
            {
                attempt++;
                try
                {
                    _logger.LogInformation($"Processing attempt {attempt} for prompt: {prompt}");

                    var response = await _httpClient.PostAsync(ApiUrl, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogWarning($"Attempt {attempt} failed with status code: {response.StatusCode}");
                        throw new Exception($"OpenAI API Error: {response.StatusCode}");
                    }

                    responseContent = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
                    string result = jsonResponse.GetProperty("choices")[0].GetProperty("text").GetString();

                    // Success reached at this point
                    success = true;
                    _logger.LogInformation($"Success on attempt {attempt}. Response: {result}");

                    return result; // Return the text generated by the API

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error on attempt {attempt}: {ex.Message}");

                    // Generate JSON log with error details
                    var errorLog = new
                    {
                        Attempt = attempt,
                        Prompt = prompt,
                        Timestamp = DateTime.UtcNow,
                        ErrorMessage = ex.Message
                    };

                    string errorLogJson = JsonSerializer.Serialize(errorLog);
                    _logger.LogError($"Error details: {errorLogJson}");

                    if (attempt >= MaxRetryAttempts)
                    {
                        _logger.LogError($"Max retry attempts reached. Failure to process prompt: {prompt}");
                        throw;  // Re-throw the exception after the last attempt
                    }

                    // Wait 15 seconds before the next retry
                    await Task.Delay(RetryDelayMilliseconds);

                }

            }
            return responseContent;  // This point will never be reached if success occurs
        }
    }
}
