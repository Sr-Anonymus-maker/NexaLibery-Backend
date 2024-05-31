using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Queries;
using NexaLibery_Backend.API.MultimediaContent.Domain.Repositories;
using NexaLibery_Backend.API.MultimediaContent.Domain.Services;


namespace NexaLibery_Backend.API.MultimediaContent.Application.Internal.QueryServices;

public class MultimediaQueryService(IMultimediaRepository multimediaRepository):IMultimediaQueryService
{
    public async Task<IEnumerable<Multimedia>> Handle(GetAllMultimediaQuery query)
    {
        return await multimediaRepository.ListAsync();
    }
}