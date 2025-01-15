namespace BoardGameSim;

public class Game
{
    public Board Board;
    public List<Player> Players;

    public Game(Board board)
    {
        Board = board;
        Players = Board.Players;
    }
    public void GameStart()
    {
        int x = 0;
        while (true)
        {
            Console.WriteLine($"Kolej gracza: {Players[x].Name}");
            int action;
            List<int> actions = new List<int> { 1, 2 };
            do
            {
                Console.WriteLine("Wybierz akcję:\n1 - ruch na planszy\n2 - wyświetlenie planszy");
                action = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (!actions.Contains(action));

            break;
        }
    }
}