using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // Undo using Z key
        {
            ChessPiece.UndoMove();
        }
        else if (Input.GetKeyDown(KeyCode.Y)) // Redo using Y key
        {
            ChessPiece.RedoMove();
        }
    }
}
