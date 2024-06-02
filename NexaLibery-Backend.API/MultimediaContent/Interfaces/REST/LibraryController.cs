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
public class LibraryController(ILibraryCommandService libraryCommandService, ILibraryQueryService libraryQueryService) : ControllerBase
{
    /**
     * Create Library content.
     * <summary>
     *     This method is responsible for handling the request to create a new Library.
     * </summary>
     * <param name="createLibraryResource">The resource containing the information to create a new Library.</param>
     * <returns>The newly created Library resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a Library",
        Description = "Creates a Library content with a given name",
        OperationId = "CreateLibrary")]
    [SwaggerResponse(201, "The Library was created", typeof(LibraryResource))]
    public async Task<IActionResult> CreateLibrary([FromBody] CreateLibraryResource createLibraryResource)
    {
        if (createLibraryResource.description.Length > 1000) 
        {
            return BadRequest("Description is too long.");
        }
        
        var createLibraryCommand = CreateLibraryCommandFromResourceAssembler.ToCommandFromEntity(createLibraryResource);
        var library = await libraryCommandService.Handle(createLibraryCommand);
        if (library is null) return BadRequest();
        var resource = LibraryResourceFromEntityAssembler.ToResourceEntity(library);
        return CreatedAtAction(nameof(CreateLibrary), new { categoryId = resource.id }, resource);
    }
    
    /**
     * Get All Library Content.
     * <summary>
     *     This method is responsible for handling the request to all Library Content.
     * </summary>
     * <returns>The Library resources.</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all Library content",
        Description = "Gets all Library",
        OperationId = "GetAllLibrary")]
    [SwaggerResponse(200, "The Library content were found", typeof(IEnumerable<LibraryResource>))]
    public async Task<IActionResult> GetAllLibrary()
    {
        var getAllLibraryQuery = new GetAllLibraryQuery();
        var categories = await libraryQueryService.Handle(getAllLibraryQuery);
        var resources = categories.Select(LibraryResourceFromEntityAssembler.ToResourceEntity);
        return Ok(resources);
    }
}