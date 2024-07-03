using System.Security.Authentication;
using AIConnector.Application.DTOs;
using AIConnector.Common.Exceptions;
using AIConnector.Infrastructure.Handlers;
using Microsoft.Extensions.Logging;

namespace AIConnector.Application.Services.Services;

public class WorklogService : IWorklogService
{
    private readonly IGPTHandler _gptHandler;
    private readonly ILogger _logger;

    public WorklogService(IGPTHandler gptHandler, ILogger<WorklogService> logger)
    {
        _gptHandler = gptHandler;
        _logger = logger;
    }

public async Task<WorklogWebhook> UpdateWorklogDescription(WorklogWebhook worklogWebhook)
{
    try
    {
        var updatedDescription = await _gptHandler.ProfessionalizeDescription(worklogWebhook.Description);
        worklogWebhook.Description = updatedDescription;
        return worklogWebhook;
    }
    catch (ExternalServiceException e)
    {
        _logger.LogError(e, "An error occurred when updating the worklog description: {ErrorMessage}", e.Message);
        // Handle retry logic, fallback, or user notification as appropriate.
        throw; // Or handle it appropriately, depending on the application context.
    }
    catch (Exception e)
    {
        _logger.LogError(e, "An unexpected error occurred when updating the worklog description: {ErrorMessage}", e.Message);
        throw; // Or handle it appropriately, depending on the application context.
    }
}
}