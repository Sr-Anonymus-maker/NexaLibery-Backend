using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Resources;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Transform;

public static class PodcastResourceFromEntityAssembler
{
    public static PodcastResource ToResourceEntity(Podcast entity)
    {
        return new PodcastResource(
            entity.id,
            entity.title,
            entity.description,
            entity.date,
            entity.pic,
            entity.url,
            entity.premium
        );
    }
}