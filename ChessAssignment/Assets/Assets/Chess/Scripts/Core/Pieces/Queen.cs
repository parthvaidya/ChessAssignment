public class Queen : SlidingPiece
{
    protected override void ShowLegalMoves()
    {
        // Diagonal
        HighlightInDirection(1, 1);
        HighlightInDirection(1, -1);
        HighlightInDirection(-1, 1);
        HighlightInDirection(-1, -1);

        // Horizontal + Vertical
        HighlightInDirection(1, 0);
        HighlightInDirection(-1, 0);
        HighlightInDirection(0, 1);
        HighlightInDirection(0, -1);
    }
}