using AIConnector.Application.DTOs;

namespace AIConnector.Application.Services.Services;

public interface IWorklogService
{
    public Task<WorklogWebhook> UpdateWorklogDescription(WorklogWebhook worklogWebhook);
}