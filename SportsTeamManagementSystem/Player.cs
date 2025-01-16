namespace SportsTeamManagementSystem;

public class Player
{
    public string Name;
    public string Position;
    public int Score;
    
    public Player(string name, string position, int score)
    {
        Name = name;
        Position = position;
        Score = score;
    }

    public void UpdateScore(int score)
    {
        Score += score;
    }
}