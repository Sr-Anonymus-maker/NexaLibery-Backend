using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Resources;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Transfrom;

public static class MultimediaResourceFromEntityAssembler
{
    public static MultimediaResource ToResourceEntity(Multimedia entity)
    {
        return new MultimediaResource(
            entity.id,
            entity.title,
            entity.description,
            entity.date,
            entity.pic,
            entity.url
        );
    }
}