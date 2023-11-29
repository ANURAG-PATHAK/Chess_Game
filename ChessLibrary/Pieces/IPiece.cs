namespace ChessLibrary
{
    public interface IPiece
    {
        /// <summary>
        /// Color of the Piece
        /// </summary>
        bool PieceColor { get; set; }
        /// <summary>
        /// Behavior of the Pieces
        /// </summary>
        IBehavior Behavior { get; set; }
    }
}