namespace SlotsGame.Contracts;

public interface IBoard
{
    void FillAndDraw();

    bool CheckIsWin(out IList<IEnumerable<ISymbol>> winningRows);
}
