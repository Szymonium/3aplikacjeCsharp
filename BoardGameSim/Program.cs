using BoardGameSim;

public class Program
{
    static void Main()
    {
        Player gracz = new Player("skibidi");
        Board plansza = new Board([gracz]);
        plansza.GenerateTurnPrizes(10);
        plansza.ShowBoard();
        
        gracz.Move();
    }
}
