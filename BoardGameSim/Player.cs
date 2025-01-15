namespace BoardGameSim;

public class Player
{
    public string Name;
    public Dictionary<char, int> Position;
    public int Score;
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

        if (dice != 0)
        {
            string direction;
            do
            {
                Console.Write($"Wylosowałeś {dice}, wybierz kierunek (Użyj strzałek): ");
                direction = Console.ReadKey().Key.ToString().Replace("Arrow", "");
                Console.WriteLine(direction);
            } while (!directions.Contains(direction));
    
            switch (direction)
            {
                case "Up":
                    Position['y'] +=  + dice;
                    break;
                case "Down":
                    Position['y'] -=  + dice;
                    break;
                case "Left":
                    Position['x'] -=  + dice;
                    break;
                case "Right":
                    Position['x'] +=  + dice;
                    break;
            }

            return;
        }
        Console.Write($"Wylosowałeś {dice}, niestety nie możesz się poruszyć ");
    }

    public void UpdateScore(int score)
    {
        Score += score;
    }
    
    public void UpdateScore()
    {
        Score *= 2;
    }
}