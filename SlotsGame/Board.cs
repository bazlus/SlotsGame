namespace SlotsGame;

using System.Text;
using SlotsGame.Contracts;
using SlotsGame.Extentions;
using SlotsGame.Models;

public class Board : IBoard
{
    private ISymbol[,] board;
    private readonly ISymbolFactory symbolFactory;

    public Board(int rows, int columns, ISymbolFactory symbolFactory)
    {
        this.symbolFactory = symbolFactory;
        this.board = new ISymbol[rows, columns];
    }

    public bool CheckIsWin(out IList<IEnumerable<ISymbol>> winningRows)
    {
        var upperBound0 = board.GetUpperBound(0);
        winningRows = new List<IEnumerable<ISymbol>>();

        for (int row = 0; row <= upperBound0; row++)
        {
            var isWin = CheckIsRowWin(row, out IEnumerable<ISymbol> symbolRowWin);

            if (isWin)
            {
                winningRows.Add(symbolRowWin);
            }
        }

        return winningRows.Any();
    }

    public void FillAndDraw()
    {
        Fill();
        Draw();
    }

    private bool CheckIsRowWin(int row, out IEnumerable<ISymbol> symbolRowWin)
    {
        symbolRowWin = board.GetRow(row);
        var firstNonWildCardSymbol = symbolRowWin.FirstOrDefault(x => x.GetType() != typeof(WildCardSymbol));
        var isWin = false;

        if (firstNonWildCardSymbol != null)
        {
            isWin = symbolRowWin.All(predicate: x => x.GetType() == firstNonWildCardSymbol.GetType() || x.GetType() == typeof(WildCardSymbol));
        }

        return isWin;
    }

    private void Fill()
    {
        var upperBound0 = board.GetUpperBound(0);
        var upperBound1 = board.GetUpperBound(1);

        for (int row = 0; row <= upperBound0; row++)
        {
            for (int col = 0; col <= upperBound1; col++)
            {
                board[row, col] = symbolFactory.GetNextSymbol();
            }
        }
    }

    private void Draw()
    {
        var upperBound0 = board.GetUpperBound(0);
        var upperBound1 = board.GetUpperBound(1);

        var sb = new StringBuilder();

        sb.Append(new String('-', upperBound0 * 3));
        sb.Append(Environment.NewLine);
        for (int row = 0; row <= upperBound0; row++)
        {
            for (int col = 0; col <= upperBound1; col++)
            {
                sb.Append('|');
                sb.Append(board[row, col].Sign);
                sb.Append('|');
            }
            sb.Append(Environment.NewLine);
        }
        sb.Append(new String('-', upperBound0 * 3));

        Console.WriteLine(sb.ToString());
    }
}