using System.Diagnostics;

namespace ConcertTicketBookingSystem;

public class Ticket
{
    public Concert Concert;
    public double Price;
    public string SeatNumber;

    public Ticket(Concert concert, double price, string seatNumber)
    {
        Concert = concert;
        Price = price;
        SeatNumber = seatNumber;
    }
}