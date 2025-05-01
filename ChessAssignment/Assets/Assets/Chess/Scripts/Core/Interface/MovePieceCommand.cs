using UnityEngine;

public class MovePieceCommand : ICommand
{
    private ChessPiece _piece;
    private Vector3 _startPosition, _endPosition;
    private int _startRow, _startCol, _endRow, _endCol;

    //save the row and column
    public MovePieceCommand(ChessPiece piece, int newRow, int newCol)
    {
        _piece = piece;
        _startRow = piece.row;
        _startCol = piece.col;
        _startPosition = piece.transform.position;

        _endRow = newRow;
        _endCol = newCol;
        _endPosition = ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol).transform.position;
    }

    // moves the piece to its new position
    public void Execute()
    {
        _piece.row = _endRow;
        _piece.col = _endCol;
        _piece.transform.position = _endPosition;
    }

    public void Undo()
    {
        _piece.row = _startRow;
        _piece.col = _startCol;
        _piece.transform.position = _startPosition;
    }
}