using BoardGameSim;

public class Program
{
    static void Main()
    {
        Player gracz1 = new Player("Skibidi");
        Player gracz5 = new Player("Szymon");
        Player gracz2 = new Player("Sigma");
        Player gracz3 = new Player("Wiktor");
        Player gracz4 = new Player("Beta");
        Board plansza = new Board([gracz1, gracz2, gracz3, gracz4, gracz5]);
        
        Game rozgrywka = new Game(plansza);
        
        rozgrywka.GameStart();
    }
}
