using BoardGameSim;

public class Program
{
    static void Main()
    {
        Board plansza = new Board(2);
        plansza.GenerateTurnPrizes(10);
        plansza.ShowBoard();

        Player gracz = new Player("skibidi");
        
        gracz.Move();
    }
}
