namespace ConcertTicketBookingSystem;

public class Concert
{
    public string Name;
    public string Date;
    public string Location;
    public List<string> AvailableSeats;

    public Concert(string name, string date, string location)
    {
        Name = name;
        Date = date;
        Location = location;
        AvailableSeats = new List<string>();
    }
}