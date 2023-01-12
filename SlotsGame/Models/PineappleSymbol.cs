namespace SlotsGame.Models;

using SlotsGame.Contracts;

public class PineappleSymbol : ISymbol
{
    public string Sign => "P";

    public decimal Multiplier => 0.8m;
}
