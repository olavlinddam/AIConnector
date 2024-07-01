using OpenAI.Chat;

namespace AIConnector.Infrastructure.Handlers;

public class GPTHandler : IGPTHandler
{
   public async Task<string> ProfessionalizeDescription(string description)
   {
       var promt = $"Update this description to be more professional. It is a description of a piece of work on a " +
                   $"software project. The returned description should be returned in the same language as you received" +
                   $"it. You should only return the description, no added text. Description: {description}.";
       var apiKey = "<your-api-key>";
       ChatClient client = new(model: "gpt-4o", apiKey);
       ChatCompletion completion = await client.CompleteChatAsync(promt);
       Console.WriteLine(completion);

       return completion.ToString();
   }
}