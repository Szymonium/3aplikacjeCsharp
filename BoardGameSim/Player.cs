namespace BoardGameSim;

public class Player
{
    public string Name;
    public Dictionary<char, int> Position;
    public double Score;

    public Player(string name)
    {
        Name = name;
        Position = new Dictionary<char, int>();
        Score = 0;
    }

    public void Move()
    {
        
    }

    public void UpdateScore()
    {
        
    }
}