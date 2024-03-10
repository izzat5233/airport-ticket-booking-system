using AirportTicketBookingSystem.Domain;
using AirportTicketBookingSystem.Domain.Interfaces;
using AirportTicketBookingSystem.Domain.Interfaces.Repository;

namespace AirportTicketBookingSystem.Infrastructure.Repository;

public class FlightRepository(
    ISimpleDatabaseService<Flight> databaseService
) : IFlightRepository
{
    private ISimpleDatabaseService<Flight> DatabaseService { get; } = databaseService;

    public void Add(Flight flight) => DatabaseService.Add(flight);

    public IEnumerable<Flight> GetAll() => DatabaseService.GetAll();

    public Flight? GetById(int flightId) => DatabaseService
        .GetAll()
        .FirstOrDefault(f => f.Id == flightId);
}