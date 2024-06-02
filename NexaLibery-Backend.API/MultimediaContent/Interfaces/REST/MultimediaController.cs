using System.Net.Mime;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Queries;
using NexaLibery_Backend.API.MultimediaContent.Domain.Services;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Mvc;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Transfrom;
using Swashbuckle.AspNetCore.Annotations;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MultimediaController : ControllerBase
{
    private readonly IMultimediaCommandService _multimediaCommandService;
    private readonly IMultimediaQueryService _multimediaQueryService;

    public MultimediaController(IMultimediaCommandService multimediaCommandService, IMultimediaQueryService multimediaQueryService)
    {
        _multimediaCommandService = multimediaCommandService;
        _multimediaQueryService = multimediaQueryService;
    }

    /// <summary>
    /// Create Multimedia content.
    /// This method is responsible for handling the request to create a new Multimedia material.
    /// </summary>
    /// <param name="createMultimediaResource">The resource containing the information to create a new Multimedia.</param>
    /// <returns>The newly created Multimedia resource.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a Multimedia",
        Description = "Creates a Multimedia with a given name",
        OperationId = "CreateMultimedia")]
    [SwaggerResponse(201, "The Multimedia material was created", typeof(MultimediaResource))]
    public async Task<IActionResult> CreateMultimedia([FromBody] CreateMultimediaResource createMultimediaResource)
    {
        if (createMultimediaResource.description.Length > 1000) 
        {
            return BadRequest("Description is too long.");
        }
        
        var createMultimediaCommand = CreateMultimediaCommandFromResourceAssembler.ToCommandFromEntity(createMultimediaResource);
        var multimedia = await _multimediaCommandService.Handle(createMultimediaCommand);
        if (multimedia is null) return BadRequest();
        var resource = MultimediaResourceFromEntityAssembler.ToResourceEntity(multimedia);
        return CreatedAtAction(nameof(CreateMultimedia), new { categoryId = resource.id }, resource);
    }
    
    /// <summary>
    /// Get All Multimedia content.
    /// This method is responsible for handling the request to get all Multimedia.
    /// </summary>
    /// <returns>The Multimedia resources.</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all Multimedia content",
        Description = "Gets all Multimedia",
        OperationId = "GetAllMultimedia")]
    [SwaggerResponse(200, "The Multimedia materials were found", typeof(IEnumerable<MultimediaResource>))]
    public async Task<IActionResult> GetAllMultimedia()
    {
        var getAllMultimediaQuery = new GetAllMultimediaQuery();
        var multimedias = await _multimediaQueryService.Handle(getAllMultimediaQuery);
        var resources = multimedias.Select(MultimediaResourceFromEntityAssembler.ToResourceEntity);
        return Ok(resources);
    }
}