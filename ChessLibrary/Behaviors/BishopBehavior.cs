using System.Collections.Generic;
using System.Drawing;

namespace ChessLibrary
{
    public class BishopBehavior : Behavior
    {
        public override List<Point> GetAllMoves(ChessBoard board, Point location, bool pieceColor)
        {
            List<Point> moves = new List<Point>();
            int startRow = location.X;
            int startCol = location.Y;
            while (startRow < board.MaxRow-1 && startCol < board.MaxColumn-1)
            {
                Point newLocation = new Point(++startRow, ++startCol);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                    break;
                }
                else
                {
                    break;
                }
            }
            startRow = location.X;
            startCol = location.Y;
            while (startCol > 0 && startRow > 0)
            {
                Point newLocation = new Point(--startRow, --startCol);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                    break;
                }
                else
                {
                    break;
                }
            }
            startRow = location.X;
            startCol = location.Y;
            while (startRow < board.MaxRow - 1 && startCol > 0)
            {
                Point newLocation = new Point(++startRow, --startCol);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                    break;
                }
                else
                {
                    break;
                }
            }
            startRow = location.X;
            startCol = location.Y;
            while (startCol < board.MaxColumn - 1 && startRow > 0)
            {
                Point newLocation = new Point(--startRow, ++startCol);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
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