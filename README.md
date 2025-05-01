# Chess Assignment
# How to Run
1. Extract files or clone the Github repository

2. Open Unity

3. Run the Game.

# File structures
Inside the core folder, there are these files :

Interface - Command manager, ICommand, Input Handler, MovePiece 

Pieces - King, Queen, Bishop, Pawn, Rook, Knight

ChessBoardPlacementHandler, ChessPieces, ChessPlayerPlacementHandler, SlidingPieces

# Pattern Used:
Command pattern for Undo/Redo 

Instructions:

1. Open the ChessPieces file

2. Uncomment the MoveTo in the  onMouseDown function

3. Click the piece and on keyborad click Z to undo and Y to redo

