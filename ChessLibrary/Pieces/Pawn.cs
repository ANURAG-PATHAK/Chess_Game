using System.Drawing;

namespace ChessLibrary
{
    public class Pawn : IPiece
    {
        public bool PieceColor { get; set; }
        public IBehavior Behavior { get; set; }
        public Pawn(bool pieceColor)
        {
            PieceColor = pieceColor;
            Behavior = new PawnBehavior();
        }
    }
}