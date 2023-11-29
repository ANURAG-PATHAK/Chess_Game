using System.Collections.Generic;
using System.Drawing;

namespace ChessLibrary
{
    public class RookBehavior : Behavior
    {
        public override List<Point> GetAllMoves(ChessBoard board, Point location, bool pieceColor)
        {
            List<Point> moves = new List<Point>();
            int startRow = location.X;
            int startCol = location.Y;
            while (startRow < board.MaxRow - 1)
            {
                Point loc = new Point(++startRow, location.Y);
                if (CanMove(board, loc))
                {
                    moves.Add(loc);
                }
                else if (CanKnock(board, loc, pieceColor))
                {
                    moves.Add(loc);
                    break;
                }
                else
                {
                    break;
                }
            }
            while (startCol < board.MaxColumn - 1)
            {
                Point loc = new Point(location.X, ++startCol);
                if (CanMove(board, loc))
                {
                    moves.Add(loc);
                }
                else if (CanKnock(board, loc, pieceColor))
                {
                    moves.Add(loc);
                    break;
                }
                else
                {
                    break;
                }
            }
            startRow = location.X;
            startCol = location.Y;
            while (startRow > 0)
            {
                Point loc = new Point(--startRow, location.Y);
                if (CanMove(board, loc ))
                {
                    moves.Add(loc);
                }
                else if (CanKnock(board, loc, pieceColor))
                {
                    moves.Add(loc);
                    break;
                }
                else
                {
                    break;
                }
            }
            while (startCol > 0)
            {
                Point loc = new Point(location.X, --startCol);
                if (CanMove(board, loc))
                {
                    moves.Add(loc);
                }
                else if (CanKnock(board, loc, pieceColor))
                {
                    moves.Add(loc);
                    break;
                }
                else
                {
                    break;
                }
            }
            return moves;
        }
    }
}
