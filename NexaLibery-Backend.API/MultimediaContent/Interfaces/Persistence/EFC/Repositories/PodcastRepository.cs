using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Repositories;
using NexaLibery_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NexaLibery_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.Persistence.EFC.Repositories;

public class PodcastRepository(AppDbContext context):BaseRepository<Podcast>(context),IPodcastRepository;