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


    public bool IsTileOccupied(Vector3 position)
    {
        // Use Physics.OverlapSphere or similar to detect if a piece is on the tile
        Collider[] hits = Physics.OverlapSphere(position, 0.1f); // Adjust radius as needed
        foreach (var hit in hits)
        {
            if (hit.gameObject.GetComponent<ChessPiece>() != null)
            {
                return true;
            }
        }
        return false;
    }


    public  void TryHighlightIfUnoccupied(int r, int c)
    {
        if (r < 0 || r >= 8 || c < 0 || c >= 8) return;

        GameObject tile = ChessBoardPlacementHandler.Instance.GetTile(r, c);
        Vector3 tilePos = tile.transform.position;

        if (IsTileOccupied(tilePos)) return;

        ChessBoardPlacementHandler.Instance.Highlight(r, c);
    }
}
