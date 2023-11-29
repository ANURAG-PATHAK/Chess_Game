namespace ChessLibrary
{
    public class Rook : IPiece
    {
        public bool PieceColor { get; set; }
        public IBehavior Behavior { get; set; }
        public Rook(bool pieceColor)
        {
            PieceColor = pieceColor;
            Behavior = new RookBehavior();
        }
    }
}