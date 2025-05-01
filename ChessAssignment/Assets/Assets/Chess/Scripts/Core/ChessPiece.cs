using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public int row, col;

    protected virtual void Start()
    {
        transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, col).transform.position;
    }

    private void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        ShowLegalMoves();
    }

    protected abstract void ShowLegalMoves();

    protected void TryHighlight(int r, int c)
    {
        if (r < 0 || r >= 8 || c < 0 || c >= 8) return;
        ChessBoardPlacementHandler.Instance.Highlight(r, c);
    }
}
