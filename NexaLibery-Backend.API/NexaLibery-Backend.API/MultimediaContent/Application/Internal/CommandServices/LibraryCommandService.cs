using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;
using NexaLibery_Backend.API.MultimediaContent.Domain.Repositories;
using NexaLibery_Backend.API.MultimediaContent.Domain.Services;
using NexaLibery_Backend.API.Shared.Domain.Repositories;

namespace NexaLibery_Backend.API.MultimediaContent.Application.Internal.CommandServices;

public class LibraryCommandService(ILibraryRepository libraryRepository,IUnitOfWork unitOfWork):ILibraryCommandService
{
    public async Task<Library> Handle(CreateLibraryCommand command)
    {
        var library = new Library(command);
        await libraryRepository.AddAsync(library);
        await unitOfWork.CompleteAsync();
        return library;
    }
    
}