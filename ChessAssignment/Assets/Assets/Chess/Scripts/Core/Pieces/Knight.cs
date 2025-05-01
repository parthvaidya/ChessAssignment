public class Knight : ChessPiece
{
    protected override void ShowLegalMoves()
    {
        // Knight movement in an "L" shape 
        int[] rowMoves = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] colMoves = { 1, -1, 1, -1, 2, -2, 2, -2 };

        for (int i = 0; i < rowMoves.Length; i++)
        {
            int newRow = row + rowMoves[i];
            int newCol = col + colMoves[i];
            TryHighlightIfUnoccupied(newRow, newCol);
           
        }
    }
}