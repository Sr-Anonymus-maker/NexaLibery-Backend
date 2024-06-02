using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Queries;
using NexaLibery_Backend.API.MultimediaContent.Domain.Repositories;
using NexaLibery_Backend.API.MultimediaContent.Domain.Services;

namespace NexaLibery_Backend.API.MultimediaContent.Application.Internal.QueryServices;

public class PodcastQueryService(IPodcastRepository podcastRepository):IPodcastQueryService
{
    public async Task<IEnumerable<Podcast>> Handle(GetAllPodcastQuery query)
    {
        return await podcastRepository.ListAsync();
    }
}