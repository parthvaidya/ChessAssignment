using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public int row, col;

    private static CommandManager commandManager = new CommandManager();

    protected virtual void Start()
    { 
        //initialize the board at start
        transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, col).transform.position;
    }

    private void OnMouseDown()
    {
        //Triggers when piece is clicked
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        ShowLegalMoves();

        //MoveTo(row + 1, col); //to test undo redo uncomment this
    }

    

    protected abstract void ShowLegalMoves(); //highlight legal moves

    protected void TryHighlight(int r, int c)
    {
        if (r < 0 || r >= 8 || c < 0 || c >= 8) return;

        ChessBoardPlacementHandler.Instance.Highlight(r, c); //A helper method to highlight a tile 
    }


    public bool IsTileOccupied(Vector3 position) 
    {
        // detect if a piece is on the tile
        Collider[] hits = Physics.OverlapSphere(position, 0.1f); 
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
        //check if unonccupied
        GameObject tile = ChessBoardPlacementHandler.Instance.GetTile(r, c);
        Vector3 tilePos = tile.transform.position;

        if (IsTileOccupied(tilePos)) return;

        ChessBoardPlacementHandler.Instance.Highlight(r, c);
    }


    //Moves the piece to a new tile only if it is unoccupied
    public void MoveTo(int newRow, int newCol)
    {
        Vector3 targetPosition = ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol).transform.position;

        if (IsTileOccupied(targetPosition))
        {
            Debug.Log("Move is blocked: Tile is occupied.");
            return;
        }

        ICommand moveCommand = new MovePieceCommand(this, newRow, newCol);
        commandManager.ExecuteCommand(moveCommand);
    }

    //undo
    public static void UndoMove()
    {
        commandManager.Undo();
    }

    //redo
    public static void RedoMove()
    {
        commandManager.Redo();
    }
}
