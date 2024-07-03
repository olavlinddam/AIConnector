using System.Security.Authentication;
using AIConnector.Common.Exceptions;
using OpenAI.Chat;
using Microsoft.Extensions.Logging;

namespace AIConnector.Infrastructure.Handlers;

public class GPTHandler : IGPTHandler
{
    private readonly ILogger<GPTHandler> _logger;

    public GPTHandler(ILogger<GPTHandler> logger)
    {
        _logger = logger;
    }

    public async Task<string> ProfessionalizeDescription(string description)
    {
        try
        {
            _logger.LogInformation("Contacting GPT to update description.");

            var promt =
                $"Update this description to be more professional. It is a description of a piece of work on a " +
                $"software project. The returned description should be returned in the same language as you received" +
                $"it. You should only return the description, no added text. Description: {description}.";
            const string apiKey = "<your-api-key>";
            ChatClient client = new(model: "gpt-4o", apiKey);
            ChatCompletion completion = await client.CompleteChatAsync(promt);
            Console.WriteLine(completion);

            return completion.ToString();
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "An HTTP error occurred when contacting the GPT API: {ErrorMessage}", e.Message);
            throw new ExternalServiceException("Error occurred while contacting the GPT API.", e);
        }
        catch (AuthenticationException e)
        {
            _logger.LogError(e, "An authentication error occurred when contacting the GPT API: {ErrorMessage}",
                e.Message);
            throw new ExternalServiceException("Authentication error occurred while contacting the GPT API.", e);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An unexpected error occurred when contacting the GPT API: {ErrorMessage}", e.Message);
            throw new ExternalServiceException("Unexpected error occurred while contacting the GPT API.", e);
        }
    }
}