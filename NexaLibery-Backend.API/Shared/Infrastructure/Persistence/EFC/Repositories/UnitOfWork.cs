using NexaLibery_Backend.API.Shared.Domain.Repositories;
using NexaLibery_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace NexaLibery_Backend.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}