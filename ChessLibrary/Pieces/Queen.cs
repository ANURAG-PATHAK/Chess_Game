using System.Drawing;

namespace ChessLibrary
{
    public class Queen : IPiece
    {
        public bool PieceColor { get; set; }
        public IBehavior Behavior { get; set; }
        public Queen(bool pieceColor)
        {
            PieceColor = pieceColor;
            Behavior = new QueenBehavior();
        }
    }
}
