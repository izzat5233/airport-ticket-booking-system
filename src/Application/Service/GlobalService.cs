using AirportTicketBookingSystem.Domain;
using AirportTicketBookingSystem.Domain.Criteria.Search;
using AirportTicketBookingSystem.Domain.Repository;
using AirportTicketBookingSystem.Domain.Service;

namespace AirportTicketBookingSystem.Application.Service;

public class GlobalService(
    IFlightRepository flightRepository
) : IGlobalService
{
    private IFlightRepository FlightRepository { get; } = flightRepository;

    public IEnumerable<Flight> SearchFlights(FlightSearchCriteria criteria)
    {
        return FlightRepository.Search(criteria);
    }
}