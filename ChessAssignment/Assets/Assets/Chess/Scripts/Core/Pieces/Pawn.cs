public class Pawn : ChessPiece
{
    protected override void ShowLegalMoves()
    {
        // Black pawn goes up the board
        TryHighlight(row + 1, col);

        
        TryHighlight(row + 1, col + 1);
        TryHighlight(row + 1, col - 1);
    }
}