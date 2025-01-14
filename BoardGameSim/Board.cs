namespace BoardGameSim;

public class Board
{
    public int Size;
    public List<List<Dictionary<string, dynamic>>> BoardArray;
    public List<Player> Players;
    Random _random = new Random();
    
    public Board(List<Player> playersArray)
    {
        Size = 15;
        BoardArray = new List<List<Dictionary<string, dynamic>>>();
        Players = playersArray;

        for (int i = 0; i < Size; i++)
        {
            BoardArray.Add(new List<Dictionary<string, dynamic>>());
            for (int j = 0; j < Size; j++)
            {
                Dictionary<string, dynamic> field = new Dictionary<string, dynamic>();
                field.Add("char", "\u2007");
                field.Add("isSpecial", _random.Next(100) < 15);
                field.Add("hasPrize", false);
                BoardArray[i].Add(field);
            }
        }

        int x = 0;
        do
        {
            int randX = _random.Next(0, Size);
            int randY = _random.Next(0, Size);
            if (BoardArray[randX][randY]["char"] == "\u2007")
            {
                BoardArray[randX][randY]["char"] = "8";
                BoardArray[randX][randY].Add("player", Players[x]);
                Players[x].Position.Add('x', randX);
                Players[x].Position.Add('y', randY);
                x++;
            }
        } while (Players.Count > x);
    }

    public void GenerateTurnPrizes(int prizeCount)
    {
        int x = 0;
        do
        {
            int randX = _random.Next(0, Size);
            int randY = _random.Next(0, Size);
            if (BoardArray[randX][randY]["char"] == "\u2007")
            {
                BoardArray[randX][randY]["char"] = "$";
                BoardArray[randX][randY]["hasPrize"] = true;
                x++;
            }
        } while (prizeCount > x);
    }

    public void ShowBoard()
    {
        foreach (var row in BoardArray)
        {
            foreach (var field in row)
            {
                Console.Write(field["char"]);
            }
            Console.WriteLine();
        }
    }
}