namespace ChessLibrary
{
    public class Bishop : IPiece
    {
        public bool PieceColor { get; set; }
        public IBehavior Behavior { get; set; }
        public Bishop(bool pieceColor)
        {
            PieceColor = pieceColor;
            Behavior = new BishopBehavior();
        }
    }
}