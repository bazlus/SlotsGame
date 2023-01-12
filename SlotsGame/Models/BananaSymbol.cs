namespace SlotsGame.Models;

using SlotsGame.Contracts;

public class BananaSymbol : ISymbol
{
    public string Sign => "B";

    public decimal Multiplier => 0.6m;
}
