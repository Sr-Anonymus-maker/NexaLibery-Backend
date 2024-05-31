using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;


namespace NexaLibery_Backend.API.MultimediaContent.Domain.Services;

public interface ILibraryCommandService
{
    Task<Library> Handle(CreateLibraryCommand command);
}