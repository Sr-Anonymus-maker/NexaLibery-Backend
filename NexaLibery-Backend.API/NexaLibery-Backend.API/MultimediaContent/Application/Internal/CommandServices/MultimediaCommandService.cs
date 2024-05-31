using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;
using NexaLibery_Backend.API.MultimediaContent.Domain.Repositories;
using NexaLibery_Backend.API.MultimediaContent.Domain.Services;
using NexaLibery_Backend.API.Shared.Domain.Repositories;

namespace NexaLibery_Backend.API.MultimediaContent.Application.Internal.CommandServices;

public class MultimediaCommandService(IMultimediaRepository multimediaRepository,IUnitOfWork unitOfWork):IMultimediaCommandService
{
    public async Task<Multimedia> Handle(CreateMultimediaCommand command)
    {
        var multimedia = new Multimedia(command);
        await multimediaRepository.AddAsync(multimedia);
        await unitOfWork.CompleteAsync();
        return multimedia;
    }
}