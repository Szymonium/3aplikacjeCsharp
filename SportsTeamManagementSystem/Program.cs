using SportsTeamManagementSystem;

public class Program
{
    static void Main()
    {
        Team druzyna = new Team();

            while (true)
            {
                Console.WriteLine("\nSports Team Management System");
                Console.WriteLine("1. Dodaj zawodnika");
                Console.WriteLine("2. Usuń zawodnika");
                Console.WriteLine("3. Zaktualizuj wynik zawodnika");
                Console.WriteLine("4. Wyświetl statystyki drużyny");
                Console.WriteLine("5. Oblicz średnią wyniku drużyny");
                Console.WriteLine("6. Wyszukaj zawodnika według pozycji");
                Console.WriteLine("7. Filtruj zawodników według wyniku");
                Console.WriteLine("8. Opuść");

                Console.Write("Wybierz opcję: ");
                int choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Console.Write("Podaj imię zawodnika: ");
                        string name = Console.ReadLine();
                        Console.Write("Podaj pozycję zawodnika: ");
                        string position = Console.ReadLine();
                        Console.Write("Podaj wynik zawodnika: ");
                        int score = int.Parse(Console.ReadLine());
                        druzyna.AddPlayer(new Player(name, position, score));
                        break;

                    case '2':
                        Console.Write("Podaj imię zawodnika do usunięcia: ");
                        string nameToRemove = Console.ReadLine();
                        druzyna.RemovePlayer(nameToRemove);
                        break;

                    case '3':
                        Console.Write("Podaj imię zawodnika do zaktualizowania wyniku: ");
                        string nameToUpdate = Console.ReadLine();
                        Console.Write("Podaj wynik do dodania: ");
                        int scoreToAdd = int.Parse(Console.ReadLine());

                        var player = druzyna.Players.FirstOrDefault(p => p.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));
                        if (player != null)
                        {
                            player.UpdateScore(scoreToAdd);
                            Console.WriteLine($"Wynik zawodnika {player.Name} został pomyślnie zaktualizowany.");
                        }
                        else
                        {
                            Console.WriteLine($"Zawodnik {nameToUpdate} nie znaleziony.");
                        }
                        break;

                    case '4':
                        druzyna.DisplayTeamStats();
                        break;

                    case '5':
                        double averageScore = Team.CalculateAverageScore(druzyna.Players);
                        Console.WriteLine($"Średni wynik drużyny: {averageScore:F2}");
                        break;

                    case '6':
                        Console.Write("Podaj pozycję do wyszukania: ");
                        string searchPosition = Console.ReadLine();
                        druzyna.SearchPlayersByPosition(searchPosition);
                        break;

                    case '7':
                        Console.Write("Podaj minimalny wynik do filtrowania zawodników: ");
                        int minScore = int.Parse(Console.ReadLine());
                        druzyna.FilterPlayersByScore(minScore);
                        break;

                    case '8':
                        Console.WriteLine("Opuszczanie systemu. Do zobaczenia!");
                        return;

                    default:
                        Console.WriteLine("Błędna opcja. Spróbuj ponownie.");
                        break;
                }
            }
    }
}