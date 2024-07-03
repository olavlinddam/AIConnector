using System.Net;
using System.Text.Json;
using AIConnector.Application.DTOs;
using AIConnector.Application.Services.Services;
using AIConnector.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AIConnector.Controllers;

[ApiController]
[Route("[controller]")]
public class TempoController : ControllerBase
{
    private readonly IWorklogService _worklogService;
    private readonly ILogger<TempoController> _logger;

    public TempoController(IWorklogService worklogService, ILogger<TempoController> logger)
    {
        _worklogService = worklogService;
        _logger = logger;
    }


    [HttpPost(Name = "WorklogDescriptionUpdater")]
    public async Task<IActionResult> UpdateWorklogDescription(WorklogWebhook worklogWebhook)
    {
        try
        {
            _logger.LogInformation("WorklogDescriptionUpdater endpoint hit.");
            var updatedWorklog = await _worklogService.UpdateWorklogDescription(worklogWebhook);
            return StatusCode(200, updatedWorklog.Description);
        }
        catch (ExternalServiceException e)
        {
            return StatusCode(500, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(404, e.Message);
        }
    }
}