using AirportTicketBookingSystem.Domain.Common;
using AirportTicketBookingSystem.Domain.Interfaces;
using AirportTicketBookingSystem.Infrastructure.Interfaces;

namespace AirportTicketBookingSystem.Infrastructure.Service.Database;

/// <summary>
/// Provides basic CRUD operations for managing entities in the database. This service enforces simple
/// constraints such as uniqueness and existence, but does not manage relational constraints or dependencies.
/// </summary>
/// <typeparam name="TEntity">The type of the entity this service manages.</typeparam>
public class DatabaseService<TEntity> : IDatabaseService<TEntity>
    where TEntity : IEntity
{
    private readonly IFileService<TEntity> _fileService;
    public DatabaseService(IFileService<TEntity> fileService) => _fileService = fileService;

    public IEnumerable<TEntity> GetAll() => _fileService.ReadAll();

    private bool Exists(TEntity entity) => GetAll().Any(e => e.Equals(entity));

    public async Task Add(TEntity entity)
    {
        if (Exists(entity)) throw new DatabaseOperationException($"Entity {entity} already exists in the database");
        await _fileService.AppendAllAsync(Enumerable.Repeat(entity, 1));
    }

    public async Task Update(TEntity newEntity)
    {
        if (!Exists(newEntity))
            throw new DatabaseOperationException($"Entity {newEntity} was not found in the database");
        var cache = GetAll().ToList();
        var changes = cache.Select(e => e.Equals(newEntity) ? newEntity : e);
        await _fileService.WriteAllAsync(changes);
    }

    public async Task Delete(TEntity entity)
    {
        if (!Exists(entity))
            throw new DatabaseOperationException($"Entity {entity} was not found in the database");
        var cache = GetAll().ToList();
        var changes = cache.Where(e => !e.Equals(entity));
        await _fileService.WriteAllAsync(changes);
    }
}