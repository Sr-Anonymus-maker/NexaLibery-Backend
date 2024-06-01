namespace NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;

public record CreateLibraryCommand(string title, string description ,string pic, string url, string premium);