namespace AIConnector.Infrastructure.Handlers;

public interface IGPTHandler
{
   public Task<string> ProfessionalizeDescription(string description);
}