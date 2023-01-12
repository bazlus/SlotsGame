namespace SlotsGame.Services;

using SlotsGame.Contracts;

public interface ICalculator
{
    decimal CalculateWinAmount(IList<IEnumerable<ISymbol>> winningRows, decimal betAmount);
}