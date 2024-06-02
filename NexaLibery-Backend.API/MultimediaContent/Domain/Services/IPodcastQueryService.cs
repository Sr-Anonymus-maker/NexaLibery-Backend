using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Queries;

namespace NexaLibery_Backend.API.MultimediaContent.Domain.Services;

public interface IPodcastQueryService
{
    Task<IEnumerable<Podcast>> Handle(GetAllPodcastQuery query);
}