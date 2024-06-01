using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Queries;
using NexaLibery_Backend.API.MultimediaContent.Domain.Repositories;
using NexaLibery_Backend.API.MultimediaContent.Domain.Services;


namespace NexaLibery_Backend.API.MultimediaContent.Application.Internal.QueryServices;

public class LibraryQueryService(ILibraryRepository libraryRepository):ILibraryQueryService
{
    public async Task<IEnumerable<Library>> Handle(GetAllLibraryQuery query)
    {
        return await libraryRepository.ListAsync();
    }
}