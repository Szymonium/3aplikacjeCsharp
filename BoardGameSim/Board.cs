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
                field.Add("char", '-');
                field.Add("isSpecial", _random.Next(100) < 15);
                field.Add("hasPrize", false);
                field.Add("players", new List<Player>());
                BoardArray[i].Add(field);
            }
        }

        int x = 0;
        do
        {
            playersArray[x].Id = x;
            int randX = _random.Next(0, Size);
            int randY = _random.Next(0, Size);
            if (BoardArray[randY][randX]["players"].Count == 0)
            {
                BoardArray[randY][randX]["players"].Add(playersArray[x]);
                Players[x].Position.Add('x', randX);
                Players[x].Position.Add('y', randY);
                x++;
            }
        } while (Players.Count > x);
    }

    public void GenerateTurnPrizes(int prizeCount)
    {
        foreach (var row in BoardArray)
        {
            foreach (var field in row)
            {
                field["hasPrize"] = false;
            }
        }
        
        int x = 0;
        do
        {
            int randX = _random.Next(0, Size);
            int randY = _random.Next(0, Size);
            if (BoardArray[randY][randX]["hasPrize"] == false && BoardArray[randY][randX]["players"].Count == 0)
            {
                BoardArray[randY][randX]["hasPrize"] = true;
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
                field["char"] = field["players"].Count == 1 ? field["players"][0].Id : field["hasPrize"] ? '$' : '-';
                field["char"] = field["players"].Count > 1 ? '%' : field["char"];
                Console.Write(field["char"]);
            }
            Console.WriteLine();
        }
    }
}