using System.Net.Mime;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Queries;
using NexaLibery_Backend.API.MultimediaContent.Domain.Services;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Resources;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PodcastController(IPodcastCommandService podcastCommandService, IPodcastQueryService podcastQueryService) : ControllerBase
{
    /**
     * Create Podcast content.
     * <summary>
     *     This method is responsible for handling the request to create a new Podcast.
     * </summary>
     * <param name="createPodcastResource">The resource containing the information to create a new Podcast.</param>
     * <returns>The newly created Podcast resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a Podcast content",
        Description = "Creates a category with a given name",
        OperationId = "CreatePodcast")]
    [SwaggerResponse(201, "The Podcast was created", typeof(PodcastResource))]
    public async Task<IActionResult> CreatePodcast([FromBody] CreatePodcastResource createPodcastResource)
    {
        if (createPodcastResource.description.Length > 1000) 
        {
            return BadRequest("Description is too long.");
        }
        
        var createPodcastCommand = CreatePodcastCommandFromResourceAssembler.ToCommandFromEntity(createPodcastResource);
        var podcast = await podcastCommandService.Handle(createPodcastCommand);
        if (podcast is null) return BadRequest();
        var resource = PodcastResourceFromEntityAssembler.ToResourceEntity(podcast);
        return CreatedAtAction(nameof(CreatePodcast), new { categoryId = resource.id }, resource);
    }
    
    /**
     * Get All Podcast content.
     * <summary>
     *     This method is responsible for handling the request to get all Podcast.
     * </summary>
     * <returns>The Podcast resources.</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all Library content",
        Description = "Gets all Library",
        OperationId = "GetAllLibrary")]
    [SwaggerResponse(200, "The Podcast were found", typeof(IEnumerable<PodcastResource>))]
    public async Task<IActionResult> GetAllPodcast()
    {
        var getAllPodcastQuery = new GetAllPodcastQuery();
        var podcast = await podcastQueryService.Handle(getAllPodcastQuery);
        var resources = podcast.Select(PodcastResourceFromEntityAssembler.ToResourceEntity);
        return Ok(resources);
    }
}