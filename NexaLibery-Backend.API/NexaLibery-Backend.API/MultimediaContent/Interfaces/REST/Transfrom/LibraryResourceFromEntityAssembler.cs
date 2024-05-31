using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Resources;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.REST.Transfrom;

public static class LibraryResourceFromEntityAssembler
{
    public static LibraryResource ToResourceEntity(Library entity)
    {
        return new LibraryResource(
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