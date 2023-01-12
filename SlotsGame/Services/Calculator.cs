namespace SlotsGame.Services;

using SlotsGame.Contracts;

public class Calculator : ICalculator
{
    public decimal CalculateWinAmount(IList<IEnumerable<ISymbol>> winningRows, decimal betAmount)
    {
        decimal totalCoefficient = 0;

        foreach (var row in winningRows)
        {
            foreach (var symbol in row)
            {
                totalCoefficient += symbol.Multiplier;
            }
        }

        return totalCoefficient * betAmount;
    }
    
}
