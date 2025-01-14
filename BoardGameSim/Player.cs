namespace BoardGameSim;

public class Player
{
    public string Name;
    public Dictionary<char, int> Position;
    public double Score;
    Random _random = new Random();

    public Player(string name)
    {
        Name = name;
        Position = new Dictionary<char, int>();
        Score = 0;
    }

    public void Move()
    {
        List<string> directions = new List<string> { "Up", "Down", "Left", "Right" };
        
        int dice = _random.Next(0, 6);
        
        string direction;
        do
        {
            Console.Write($"Wylosowałeś {dice}, wybierz kierunek (Użyj strzałek): ");
            direction = Console.ReadKey().Key.ToString().Replace("Arrow", "");
            Console.WriteLine(direction);
        } while (!directions.Contains(direction));

        
    }

    public void UpdateScore()
    {
        
    }
}