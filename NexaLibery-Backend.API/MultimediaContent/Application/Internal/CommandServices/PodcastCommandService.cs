using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;
using NexaLibery_Backend.API.MultimediaContent.Domain.Repositories;
using NexaLibery_Backend.API.MultimediaContent.Domain.Services;
using NexaLibery_Backend.API.Shared.Domain.Repositories;

namespace NexaLibery_Backend.API.MultimediaContent.Application.Internal.CommandServices;

public class PodcastCommandService(IPodcastRepository podcastRepository,IUnitOfWork unitOfWork):IPodcastCommandService
{
    public async Task<Podcast> Handle(CreatePodcastCommand command)
    {
        var podcast = new Podcast(command);
        await podcastRepository.AddAsync(podcast);
        await unitOfWork.CompleteAsync();
        return podcast;
    }
}