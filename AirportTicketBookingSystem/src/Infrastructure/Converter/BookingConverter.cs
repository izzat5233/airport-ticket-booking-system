using AirportTicketBookingSystem.Application.Interfaces;
using AirportTicketBookingSystem.Domain;
using AirportTicketBookingSystem.Infrastructure.Converter.Utility;

namespace AirportTicketBookingSystem.Infrastructure.Converter;

public class BookingConverter : ICsvEntityConverter<Booking>
{
    public Booking CsvToEntity(string csvLine)
    {
        var parts = csvLine.SplitToLengthOrThrow(3);
        var flightId = parts[0].ParseOrThrowInt();
        var passengerId = parts[1].ParseOrThrowInt();
        var flightClass = parts[2].ParseFlightClassOrThrow();
        return new Booking(flightId, passengerId, flightClass);
    }

    public string EntityToCsv(Booking entity) =>
        $"{entity.FlightId},{entity.PassengerId},{entity.BookingClass}";
}