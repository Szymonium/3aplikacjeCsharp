using System.Diagnostics;

namespace ConcertTicketBookingSystem;

public class Ticket
{
    public Concert Concert;
    public decimal Price;
    public int SeatNumber;

    public Ticket(Concert concert, decimal price, int seatNumber)
    {
        Concert = concert;
        Price = price;
        SeatNumber = seatNumber;
    }
    
    public override string ToString()
    {
        return $"Bilet na {Concert.Name} w {Concert.Location} dnia {Concert.Date.ToShortDateString()} | Miejsce: {SeatNumber} | Cena: {Price} PLN";
    }
}