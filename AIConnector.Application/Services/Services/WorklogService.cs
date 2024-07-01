using AIConnector.Application.DTOs;
using AIConnector.Infrastructure.Handlers;

namespace AIConnector.Application.Services.Services;

public class WorklogService : IWorklogService
{
   private readonly IGPTHandler _gptHandler;

   public WorklogService(IGPTHandler gptHandler)
   {
      _gptHandler = gptHandler;
   }

   public async Task<WorklogWebhook> UpdateWorklogDescription(WorklogWebhook worklogWebhook)
   {
      var updatedDescription = await _gptHandler.ProfessionalizeDescription(worklogWebhook.Description);
      worklogWebhook.Description = updatedDescription;
      return worklogWebhook;
   }
}