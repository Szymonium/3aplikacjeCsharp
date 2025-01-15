using BoardGameSim;

public class Program
{
    static void Main()
    {
        Player gracz = new Player("skibidi");
        Board plansza = new Board([gracz]);
        
        Game rozgrywka = new Game(plansza);
        rozgrywka.GameStart();
    }
}
