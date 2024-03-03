using AirportTicketBookingSystem.Domain.Criteria.Search;

namespace AirportTicketBookingSystem.Domain.Repository;

/// <summary>
/// Defines the interface for flight repository operations, providing methods for adding, retrieving,
/// searching, and filtering flights.
/// </summary>
public interface IFlightRepository
{
    /// <summary>
    /// Adds a new flight to the repository.
    /// </summary>
    /// <param name="flight">The flight to add.</param>
    /// <exception cref="ArgumentException">Thrown when a flight with the same identifier already exists in the repository.</exception>
    public void Add(Flight flight);

    /// <summary>
    /// Asynchronously adds multiple flights to the repository.
    /// </summary>
    /// <param name="flights">The collection of flights to add.</param>
    /// <returns>An empty collection of tasks.</returns>
    [Obsolete("Method not implemented yet")]
    public IEnumerable<Task> AddAllAsync(IEnumerable<Flight> flights) => Enumerable.Empty<Task>();

    /// <summary>
    /// Retrieves a flight by its identifier.
    /// </summary>
    /// <param name="flightId">The unique identifier of the flight.</param>
    /// <returns>The flight with the specified identifier, or null if no such flight exists.</returns>
    public Flight? GetById(int flightId);

    /// <summary>
    /// Searches for flights matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria to apply to the search.</param>
    /// <returns>A collection of flights that match the search criteria.</returns>
    public IEnumerable<Flight> Search(FlightSearchCriteria criteria);

    /// <summary>
    /// Filters a given collection of flights based on the specified criteria.
    /// </summary>
    /// <param name="flights">The collection of flights to filter.</param>
    /// <param name="criteria">The criteria to apply to the filtering.</param>
    /// <returns>A collection of flights that meet the filter criteria.</returns>
    public IEnumerable<Flight> Filter(IEnumerable<Flight> flights, FlightSearchCriteria criteria);
}