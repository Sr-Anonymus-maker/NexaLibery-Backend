using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Repositories;
using NexaLibery_Backend.API.Shared.Infrastructure.EFC.Repositories;
using NexaLibery_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace NexaLibery_Backend.API.MultimediaContent.Interfaces.Persistence.EFC.Repositories;

public class LibraryRepository(AppDbContext context):BaseRepository<Library>(context),ILibraryRepository;