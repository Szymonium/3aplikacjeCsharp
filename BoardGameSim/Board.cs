namespace BoardGameSim;

public class Board
{
    public int Size;
    public List<List<string>> BoardArray;

    public Board(int playerCount)
    {
        Size = 10;
        BoardArray = new List<List<string>>();

        for (int i = 0; i < Size; i++)
        {
            BoardArray.Add(new List<string>());
            for (int j = 0; j < Size; j++)
            {
                BoardArray[i][j] = "\u2007";
            }
        }

        int x = 0;
        do
        {
            int randX = Random.Range(0, Size);
            int randY = Random.Range(0, Size);
            if (BoardArray[randX][randY] == "\u2007")
            {
                BoardArray[randX][randY] = "8";
                x++;
            }
        } while (playerCount < x);
    }

    public void GenerateTurnPrizes(int prizeCount)
    {
        int x = 0;
        do
        {
            int randX = Random.Range(0, Size);
            int randY = Random.Range(0, Size);
            if (BoardArray[randX][randY] == "\u2007")
            {
                BoardArray[randX][randY] = "$";
                x++;
            }
        } while (prizeCount < x);
    }
}