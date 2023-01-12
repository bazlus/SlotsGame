namespace SlotsGame.Factories;

using SlotsGame.Contracts;
using SlotsGame.Models;

public class SymbolFactory : ISymbolFactory
{
    private const int AppleProbability = 45;
    private const int BananaProbability = 35;
    private const int PineAppleProbability = 15;
    private const int WildCardProbability = 5;

    public ISymbol GetNextSymbol()
    {
        var randomSelection = new Random().Next(0, 100);

        var result = randomSelection switch
        {
            < AppleProbability => (ISymbol)new AppleSymbol(),
            < AppleProbability + BananaProbability => new BananaSymbol(),
            < AppleProbability + BananaProbability + PineAppleProbability => new PineappleSymbol(),
            < AppleProbability + BananaProbability + PineAppleProbability + WildCardProbability => new WildCardSymbol(),
            _ => throw new Exception("Invalid random selected"),
        };

        return result;
    }
}
