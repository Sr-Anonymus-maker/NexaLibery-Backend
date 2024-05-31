using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Queries;

namespace NexaLibery_Backend.API.MultimediaContent.Domain.Services;

public interface ILibraryQueryService
{
    Task<IEnumerable<Library>> Handle(GetAllLibraryQuery query);
}