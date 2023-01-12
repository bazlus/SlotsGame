namespace SlotsGame.Models;

using SlotsGame.Contracts;

public class AppleSymbol : ISymbol
{
    public string Sign => "A";
     
    public decimal Multiplier => 0.4m;
}
