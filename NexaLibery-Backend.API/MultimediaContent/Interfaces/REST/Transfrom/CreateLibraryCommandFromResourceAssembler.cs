using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Resources;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Transfrom;

public static class CreateLibraryCommandFromResourceAssembler
{
    public static CreateLibraryCommand ToCommandFromEntity(CreateLibraryResource resource)
    {
        return new CreateLibraryCommand(
            resource.title,
            resource.description,
            resource.pic,
            resource.url,
            resource.premium
        );
    }
}