using System.Collections.Generic;
using System.Drawing;

namespace ChessLibrary
{
    public abstract class Behavior : IBehavior
    {
        protected bool CanMove(ChessBoard board, Point location)
        {
            return board[location].Piece == null;
        }
        protected bool CanKnock(ChessBoard board, Point location, bool pieceColor)
        {
            IPiece piece = board[location].Piece;
            if (piece != null)
            {
                if (piece.PieceColor != pieceColor)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public abstract List<Point> GetAllMoves(ChessBoard board, Point location, bool pieceColor);
    }
}