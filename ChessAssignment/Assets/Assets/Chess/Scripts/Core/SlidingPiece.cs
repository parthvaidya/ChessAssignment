
using UnityEngine;

public abstract class SlidingPiece : ChessPiece
{
    protected void HighlightInDirection(int rowDir, int colDir)
    {
        int r = row + rowDir;
        int c = col + colDir;

        while (r >= 0 && r < 8 && c >= 0 && c < 8)
        {
            GameObject tile = ChessBoardPlacementHandler.Instance.GetTile(r, c);
            Vector3 tilePos = tile.transform.position;

            if (IsTileOccupied(tilePos))
            {
                break; // There's a piece here, stop
            }
            TryHighlight(r, c);
            r += rowDir;
            c += colDir;
        }
    }
}
