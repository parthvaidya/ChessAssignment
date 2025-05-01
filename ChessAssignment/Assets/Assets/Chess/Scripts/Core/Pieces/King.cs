public class King : ChessPiece
{
    protected override void ShowLegalMoves()
    {
        // King moves one square in any direction
        int[] rowMoves = { 1, 1, 1, 0, 0, -1, -1, -1 };
        int[] colMoves = { 0, 1, -1, 1, -1, 0, 1, -1 };

        for (int i = 0; i < rowMoves.Length; i++)
        {
            int newRow = row + rowMoves[i];
            int newCol = col + colMoves[i];
            TryHighlightIfUnoccupied(newRow, newCol);
            //TryHighlight(newRow, newCol);
        }
    }
}