using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Resources;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Transform;

public static class CreatePodcastCommandFromResourceAssembler
{
    public static CreatePodcastCommand ToCommandFromEntity(CreatePodcastResource resource)
    {
        return new CreatePodcastCommand(
            resource.title,
            resource.description,
            resource.pic,
            resource.url,
            resource.premium
        );
    }
}