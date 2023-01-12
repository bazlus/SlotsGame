namespace SlotsGame.Extentions;

using SlotsGame.Contracts;

public static class MultidimetionalArrayExtentions
{
    public static IList<ISymbol> GetRow(this ISymbol[,] symbols, int rowIndex)
    {
        return Enumerable.Range(0, symbols.GetLength(1))
                .Select(x => symbols[rowIndex, x])
                .ToArray();
    }
}
