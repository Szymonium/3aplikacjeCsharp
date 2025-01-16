namespace ConcertTicketBookingSystem;

public interface IConcertType
{
    string GetDetails();
}

public class Concert
{
    public string Name;
    public DateTime Date;
    public string Location;
    public int AvailableSeats;

    public Concert(string name, DateTime date, string location, int availableSeats)
    {
        Name = name;
        Date = date;
        Location = location;
        AvailableSeats = availableSeats;
    }
    
    public override string ToString()
    {
        return $"{Name} | {Date.ToShortDateString()} | {Location} | Dostępnych miejsc: {AvailableSeats}";
    }
}

public class RegularConcert : Concert, IConcertType
{
    public RegularConcert(string name, DateTime date, string location, int availableSeats)
        : base(name, date, location, availableSeats) { }

    public string GetDetails()
    {
        return "Zwykły koncert cenowany standardowo.";
    }
}

public class VIPConcert : Concert, IConcertType
{
    public VIPConcert(string name, DateTime date, string location, int availableSeats)
        : base(name, date, location, availableSeats) { }

    public string GetDetails()
    {
        return "Ekskluzywny koncert VIP z możliwością spotkania z artystami.";
    }
}

public class OnlineConcert : Concert, IConcertType
{
    public string Platform;

    public OnlineConcert(string name, DateTime date, string platform, int availableSeats)
        : base(name, date, "Online", availableSeats)
    {
        Platform = platform;
    }

    public string GetDetails()
    {
        return $"Koncert online streamowany na platformie {Platform}.";
    }
}

public class PrivateConcert : Concert, IConcertType
{
    public PrivateConcert(string name, DateTime date, string location, int availableSeats)
        : base(name, date, location, availableSeats) { }

    public string GetDetails()
    {
        return "Prywatny koncert dla zamkniętej grupy osób.";
    }
}