using System.Drawing;

namespace ChessLibrary
{
    public class King : IPiece
    {
        public bool PieceColor { get; set; }
        public IBehavior Behavior { get; set; }
        public King(bool pieceColor)
        {
            PieceColor = pieceColor;
            Behavior = new KingBehavior();
        }
    }
}