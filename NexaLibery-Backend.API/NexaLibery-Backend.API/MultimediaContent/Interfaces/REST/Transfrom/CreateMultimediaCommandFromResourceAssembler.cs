using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Resources;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Transfrom;

public static class CreateMultimediaCommandFromResourceAssembler
{
    public static CreateMultimediaCommand ToCommandFromEntity(CreateMultimediaResource resource)
    {
        return new CreateMultimediaCommand(
            resource.title,
            resource.description,
            resource.pic,
            resource.url,
            resource.premium
        );
    }
}