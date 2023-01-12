namespace SlotsGame.Models;

using SlotsGame.Contracts;

public class WildCardSymbol : ISymbol
{
    public string Sign => "7";

    public decimal Multiplier => 0m;
}
