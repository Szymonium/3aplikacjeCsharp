namespace ConcertTicketBookingSystem;

public class BookingSystem
{
    private List<Concert> Concerts = new List<Concert>();
    private List<Ticket> Tickets = new List<Ticket>();

    public void AddConcert(Concert concert)
    {
        Concerts.Add(concert);
        Console.WriteLine($"Dodano koncert: {concert.Name}");
    }

    public void DisplayConcerts(Func<Concert, bool> filter)
    {
        var filteredConcerts = Concerts.Where(filter);

        foreach (var concert in filteredConcerts)
        {
            Console.WriteLine(concert);
        }
    }

    public void BookTicket(string concertName, decimal price)
    {
        var concert = Concerts.FirstOrDefault(c => c.Name == concertName);
        if (concert == null || concert.AvailableSeats <= 0)
        {
            Console.WriteLine("Koncertu nie znaleziono lub brak wolnych miejsc.");
            return;
        }

        int seatNumber = concert.AvailableSeats;
        concert.AvailableSeats--;

        var ticket = new Ticket(concert, price, seatNumber);
        Tickets.Add(ticket);

        Console.WriteLine($"Kupiony bilet: {ticket}");
    }

    public void GenerateReport()
    {
        Console.WriteLine("Raport sprzedaży biletów:");
        Console.WriteLine($"Ilość sprzedanych biletów: {Tickets.Count}");
        foreach (var ticket in Tickets)
        {
            Console.WriteLine(ticket);
        }
    }
}