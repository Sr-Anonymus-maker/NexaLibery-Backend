using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;


namespace NexaLibery_Backend.API.MultimediaContent.Domain.Services;

public interface IMultimediaCommandService
{
    Task<Multimedia> Handle(CreateMultimediaCommand command);
    
}