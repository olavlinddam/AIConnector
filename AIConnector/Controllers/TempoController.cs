using System.Text.Json;
using AIConnector.Application.DTOs;
using AIConnector.Application.Services.Services;
using Microsoft.AspNetCore.Mvc;
namespace AIConnector.Controllers;

[ApiController]
[Route("[controller]")]

public class TempoController
{
    private readonly IWorklogService _worklogService;

    public TempoController(IWorklogService worklogService)
    {
        _worklogService = worklogService;
    }


    [HttpPost(Name = "WorklogDescriptionUpdater")]
    public async Task<string> UpdateWorklogDescription(WorklogWebhook worklogWebhook)
    {
        var updatedWorklog = await _worklogService.UpdateWorklogDescription(worklogWebhook);
        return updatedWorklog.Description;
    }
}