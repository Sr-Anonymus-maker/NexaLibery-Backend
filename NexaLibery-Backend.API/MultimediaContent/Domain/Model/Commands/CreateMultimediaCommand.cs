namespace NexaLibery_Backend.API.MultimediaContent.Domain.Model.Commands;

public record CreateMultimediaCommand(string title, string description ,string pic, string url,string premium);