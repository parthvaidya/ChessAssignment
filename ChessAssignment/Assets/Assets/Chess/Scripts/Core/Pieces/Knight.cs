public class Knight : ChessPiece
{
    protected override void ShowLegalMoves()
    {
        // Knight moves in an "L" shape (2 squares in one direction, 1 square in the perpendicular direction)
        int[] rowMoves = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] colMoves = { 1, -1, 1, -1, 2, -2, 2, -2 };

        for (int i = 0; i < rowMoves.Length; i++)
        {
            int newRow = row + rowMoves[i];
            int newCol = col + colMoves[i];
            TryHighlight(newRow, newCol);
        }
    }
}