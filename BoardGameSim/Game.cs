namespace BoardGameSim;

public delegate void Delegate();
public delegate void DelegateWArg(int argument);

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
        Delegate show = Board.ShowBoard;
        DelegateWArg genPrizes = Board.GenerateTurnPrizes;
        
        genPrizes(Players.Count * 2);
        
        int x = 0;
        int turns = 0;
        while (turns < 3)
        {
            Player currPlayer = Players[x];
            Console.WriteLine($"Kolej gracza: {currPlayer.Id}. {currPlayer.Name}");
            char action;
            List<char> actions = new List<char> { '1', '2', '3' };
            do
            {
                Console.WriteLine("Wybierz akcję:\n1 - ruch na planszy\n2 - wyświetlenie planszy\n3 - zresetuj nagrody");
                action = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (!actions.Contains(action));
            
            Delegate move = currPlayer.Move;
            Delegate doubleScore = currPlayer.UpdateScore;
            DelegateWArg addScore = currPlayer.UpdateScore;
            
            switch (action)
            {
                case '1':
                    int preMoveX = currPlayer.Position['x'];
                    int preMoveY = currPlayer.Position['y'];
                    
                    move();
                    
                    int postMoveX = currPlayer.Position['x'] >= Board.Size ? Board.Size - 1: currPlayer.Position['x'] < 0 ? 0 : currPlayer.Position['x'];
                    int postMoveY = currPlayer.Position['y'] >= Board.Size ? Board.Size - 1 : currPlayer.Position['y'] < 0 ? 0 : currPlayer.Position['y'];
                    
                    Board.BoardArray[preMoveY][preMoveX]["players"].Remove(currPlayer);
                    Board.BoardArray[postMoveY][postMoveX]["players"].Add(currPlayer);

                    if (Board.BoardArray[postMoveY][postMoveX]["hasPrize"])
                    {
                        int addedScore = 15;
                        addScore(addedScore);
                        Console.WriteLine($"Znalazłeś nagrodę i zdobyłeś {addedScore} punktów! Twój obecny wynik wynosi: {currPlayer.Score}");
                        Board.BoardArray[postMoveY][postMoveX]["hasPrize"] = false;
                    }
                    else if (Board.BoardArray[postMoveY][postMoveX]["isSpecial"])
                    {
                        doubleScore();
                        Console.WriteLine($"Znalazłeś specjalne pole, które podwoiło twoje punkty!!! Twój obecny wynik wynosi: {currPlayer.Score}");
                        Board.BoardArray[postMoveY][postMoveX]["isSpecial"] = false;
                    }
                    break;
                
                case '2':
                    show();
                    break;
                
                case '3':
                    Console.WriteLine("Podaj ilość nowych nagród: ");
                    int prizeQuantity = Convert.ToInt32(Console.ReadLine());
                    if (prizeQuantity.GetType() != typeof(int)) prizeQuantity = Players.Count * 2;
                    genPrizes(prizeQuantity);
                    Console.WriteLine($"Wygenerowano {prizeQuantity} nagród!");
                    break;
            }

            x++;
            if (x == Players.Count)
            {
                x = 0; turns++;
            }

            Console.WriteLine("Naciśnij aby skończyć turę");
            Console.ReadKey();
            Console.Clear();
        }
    }
}