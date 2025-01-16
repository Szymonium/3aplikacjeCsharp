namespace SportsTeamManagementSystem;

public class Team
{
    public List<Player> Players = new List<Player>();

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            Console.WriteLine($"Zawodnik {player.Name} został dodany do drużyny.");
        }

        public void RemovePlayer(string name)
        {
            var player = Players.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (player != null)
            {
                Players.Remove(player);
                Console.WriteLine($"Zawodnik {name} został usunięty z drużyny.");
            }
            else
            {
                Console.WriteLine($"Zawodnika {name} nie znaleziono.");
            }
        }

        public void DisplayTeamStats()
        {
            Console.WriteLine("Statystyki drużyny:");
            foreach (var player in Players)
            {
                Console.WriteLine($"Imię: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
            }
        }

        public static double CalculateAverageScore(List<Player> players)
        {
            return players.Any() ? players.Average(p => p.Score) : 0;
        }

        public void SearchPlayersByPosition(string position)
        {
            var filteredPlayers = Players.Where(p => p.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filteredPlayers.Any())
            {
                Console.WriteLine($"Zawodnicy na pozycji {position}:");
                foreach (var player in filteredPlayers)
                {
                    Console.WriteLine($"Imię: {player.Name}, Wynik: {player.Score}");
                }
            }
            else
            {
                Console.WriteLine($"Nie znaleziono zawodników na pozycji {position}.");
            }
        }

        public void FilterPlayersByScore(int minScore)
        {
            var filteredPlayers = Players.Where(p => p.Score >= minScore).ToList();

            if (filteredPlayers.Any())
            {
                Console.WriteLine($"Zawodnicy z wynikiem >= {minScore}:");
                foreach (var player in filteredPlayers)
                {
                    Console.WriteLine($"Imię: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
                }
            }
            else
            {
                Console.WriteLine($"Nie znaleziono zawodników z wynikiem >= {minScore}.");
            }
        }
}