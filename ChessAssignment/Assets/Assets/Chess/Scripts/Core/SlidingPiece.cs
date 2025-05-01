using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlidingPiece : ChessPiece
{
    protected void HighlightInDirection(int rowDir, int colDir)
    {
        int r = row + rowDir;
        int c = col + colDir;

        while (r >= 0 && r < 8 && c >= 0 && c < 8)
        {
            TryHighlight(r, c);
            r += rowDir;
            c += colDir;
        }
    }
}
