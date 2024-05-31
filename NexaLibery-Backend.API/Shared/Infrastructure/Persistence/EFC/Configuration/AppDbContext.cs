using NexaLibery_Backend.API.MultimediaContent.Domain.Model.Aggregates;
using NexaLibery_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace NexaLibery_Backend.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // MultimediaContent Context
        builder.Entity<Library>().ToTable("Library");
        builder.Entity<Library>().HasKey(l => l.id);
        builder.Entity<Library>().Property(l => l.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Library>().Property(l => l.title).IsRequired().HasMaxLength(1000);
        builder.Entity<Library>().Property(l => l.description).IsRequired().HasMaxLength(1000);
        builder.Entity<Library>().Property(l => l.date)
            .IsRequired()
            .HasColumnType("TIMESTAMP")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
        builder.Entity<Library>().Property(l => l.pic).IsRequired().HasMaxLength(1000);
        builder.Entity<Library>().Property(l => l.url).IsRequired().HasMaxLength(1000);
        builder.Entity<Library>().Property(l => l.premium).IsRequired().HasMaxLength(1000);
     
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}