using ConcertTicketBookingSystem;

public class Program
{
    static void Main()
    {
        BookingSystem systemBookowania = new BookingSystem();

        systemBookowania.AddConcert(new RegularConcert("Rock Fest", DateTime.Now.AddDays(10), "Klub Sowa", 100));
        systemBookowania.AddConcert(new RegularConcert("Metal Revolution", DateTime.Now.AddDays(10), "Klub Sowa", 100));
        systemBookowania.AddConcert(new VIPConcert("Jazzowa Noc", DateTime.Now.AddDays(15), "Carpenter Pub", 50));
        systemBookowania.AddConcert(new PrivateConcert("Jammowanie", DateTime.Now.AddDays(15), "Carpenter Pub", 50));
        systemBookowania.AddConcert(new OnlineConcert("Virtualny Pop", DateTime.Now.AddDays(20), "YouTube", 1000));
        systemBookowania.AddConcert(new PrivateConcert("Ekskluzywna Opera", DateTime.Now.AddDays(25), "Scena Zgrzyt", 20));
        systemBookowania.AddConcert(new PrivateConcert("Ultimate Emo Party", DateTime.Now.AddDays(25), "Scena Zgrzyt", 20));

        Console.WriteLine("Dostępne koncerty:");
        systemBookowania.DisplayConcerts(c => true);

        systemBookowania.BookTicket("Rock Fest", 50.0m);
        systemBookowania.BookTicket("Jazzowa Noc", 150.0m);

        systemBookowania.GenerateReport();

        Console.WriteLine("\nKoncerty w Klubie Sowa:");
        systemBookowania.DisplayConcerts(c => c.Location == "Klub Sowa");
    }
}