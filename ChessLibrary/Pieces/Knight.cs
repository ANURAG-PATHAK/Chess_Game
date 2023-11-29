using System.Drawing;

namespace ChessLibrary
{
    public class Knight: IPiece
    {
        public bool PieceColor { get; set; }
        public IBehavior Behavior { get; set; }
        public Knight(bool pieceColor)
        {
            PieceColor = pieceColor;
            Behavior = new KnightBehavior();
        }
    }
}