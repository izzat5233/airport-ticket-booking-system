using AirportTicketBookingSystem.Domain.Interfaces;

namespace AirportTicketBookingSystem.Infrastructure.Interfaces;

/// <summary>
/// Defines the basic database methods for managing entities of type <typeparamref name="TEntity"/>.
/// </summary>
/// <typeparam name="TEntity">Type of domain entity.</typeparam>
public interface IDatabaseService<TEntity> : IQueryDatabaseService<TEntity>, ICrudDatabaseService<TEntity>
    where TEntity : IEntity
{
}