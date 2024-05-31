﻿using System.Net.Mime;
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
public class MultimediaController(IMultimediaCommandService multimediaCommandService, IMultimediaQueryService multimediaQueryService) : ControllerBase
{
    /**
     * Create Library.
     * <summary>
     *     This method is responsible for handling the request to create a new Library material.
     * </summary>
     * <param name="createMultimediaResource">The resource containing the information to create a new Library.</param>
     * <returns>The newly created Library resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a Multimedia",
        Description = "Creates a category with a given name",
        OperationId = "CreateMultimedia")]
    [SwaggerResponse(201, "The Multimedia material was created", typeof(MultimediaResource))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateMultimediaResource createMultimediaResource)
    {
        if (CreateMultimediaResource.description.Length > 1000) 
        {
            return BadRequest("Description is too long.");
        }
        
        var createMultimediaCommand = CreateMultimediaCommandFromResourceAssembler.ToCommandFromEntity(createMultimediaResource);
        var multimedia = await multimediaCommandService.Handle(createMultimediaCommand);
        if (multimedia is null) return BadRequest();
        var resource = MultimediaResourceFromEntityAssembler.ToResourceEntity(multimedia);
        return CreatedAtAction(nameof(CreateCategory), new { categoryId = resource.id }, resource);
    }
    
    /**
     * Get All Library content.
     * <summary>
     *     This method is responsible for handling the request to get all Multimedia.
     * </summary>
     * <returns>The Multimedia resources.</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all Multimedia content",
        Description = "Gets all Multimedia",
        OperationId = "GetAllMultimedia")]
    [SwaggerResponse(200, "The Multimedia materials were found", typeof(IEnumerable<MultimediaResource>))]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllMultimediaQuery = new GetAllMultimediaQuery();
        var categories = await multimediaQueryService.Handle(getAllMultimediaQuery);
        var resources = categories.Select(MultimediaResourceFromEntityAssembler.ToResourceEntity);
        return Ok(resources);
    }
}