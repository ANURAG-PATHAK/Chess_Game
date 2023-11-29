using System.Collections.Generic;
using System.Drawing;

namespace ChessLibrary
{
    public class KnightBehavior : Behavior
    {
        public override List<Point> GetAllMoves(ChessBoard board, Point location, bool pieceColor)
        {
            List<Point> moves = new List<Point>();
            if (location.X < board.MaxRow-2 && location.Y < board.MaxColumn-1)
            {
                Point newLocation = new Point(location.X + 2, location.Y + 1);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                }
            }
            if (location.X < board.MaxRow-1 && location.Y < board.MaxColumn-2)
            {
                Point newLocation = new Point(location.X + 1, location.Y + 2);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                }
            }
            if (location.X > 0 && location.Y < board.MaxColumn-2)
            {
                Point newLocation = new Point    (location.X - 1, location.Y + 2);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                }
            }
            if (location.X > 1 && location.Y < board.MaxColumn-1)
            {
                Point newLocation = new Point(location.X - 2, location.Y + 1);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                }
            }
            if (location.X < board.MaxRow - 2 && location.Y > 0)
            {
                Point newLocation = new Point(location.X + 2, location.Y - 1);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                }
            }
            if (location.X < board.MaxRow-1 && location.Y > 1)
            {
                Point newLocation = new Point(location.X + 1, location.Y - 2);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                }
            }
            if (location.X > 1 && location.Y > 0)
            {
                Point newLocation = new Point(location.X - 2, location.Y - 1);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                }
            }
            if (location.X > 0 && location.Y > 1)
            {
                Point newLocation = new Point(location.X - 1, location.Y - 2);
                if (CanMove(board, newLocation))
                {
                    moves.Add(newLocation);
                }
                else if (CanKnock(board, newLocation, pieceColor))
                {
                    moves.Add(newLocation);
                }
            }
            return moves;
        }
    }
}
