namespace SlotsGame;

using SlotsGame.Contracts;
using SlotsGame.Services;

public class GameEngine
{
    private readonly ICalculator calculator;
    private readonly IBoard board;

    private decimal balance;

    public GameEngine(IBoard board, ICalculator calculator)
    {
        this.board = board;
        this.calculator = calculator;
    }

    public void Start()
    {
        Console.WriteLine("Please deposit money you would like to play with:");
        decimal initialBalance;
        initialBalance = GetInputAmount();
        this.balance = initialBalance;

        while (true)
        {
            Console.WriteLine("Place bet:");
            var betAmount = GetInputAmount();
            if (this.balance - betAmount < 0)
            {
                Console.WriteLine($"Not enough funds. Your balance is {this.balance}");
                continue;
            }
            this.balance -= betAmount;

            this.board.FillAndDraw();

            if (this.board.CheckIsWin(out var winningRows))
            {
                var calculatedWin = this.calculator.CalculateWinAmount(winningRows, betAmount);
                this.balance += calculatedWin;

                Console.WriteLine($"You won: {calculatedWin:f2}! Your balance is now {this.balance:f2}.");
            }

            if (this.balance <= 0)
            {
                Console.WriteLine("Thanks for playing.");
                Environment.Exit(0);
            }
        } 
    }

    private decimal GetInputAmount()
    {
        decimal initialBalance;
        while (true)
        {
            var initialBalanceStr = Console.ReadLine();
            if (decimal.TryParse(initialBalanceStr, out initialBalance))
            {
                return initialBalance;
            }

            Console.WriteLine("Invalid amount. Please try again.");
        }
    }


   
}
