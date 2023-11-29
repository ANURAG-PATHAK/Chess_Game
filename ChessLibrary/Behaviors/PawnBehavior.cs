using System.Collections.Generic;
using System.Drawing;

namespace ChessLibrary
{
    public class PawnBehavior : Behavior
    {
        public override List<Point> GetAllMoves(ChessBoard board, Point location, bool pieceColor)
        {
            List<Point> moves = new List<Point>();
            if (pieceColor == board.IsLight)
            {
                if (location.X == 1)
                {
                    if (CanMove(board, new Point(location.X + 1, location.Y)))
                    {
                        moves.Add(new Point(location.X + 1, location.Y));
                        if (CanMove(board, new Point(location.X + 2, location.Y)))
                        {
                            moves.Add(new Point(location.X + 2, location.Y));
                        }
                    }
                    if (location.Y < board.MaxColumn - 1 && CanKnock(board, new Point(location.X + 1, location.Y + 1), pieceColor))
                    {
                        moves.Add(new Point(location.X + 1, location.Y + 1));
                    }
                    if (location.Y > 0 && CanKnock(board, new Point(location.X + 1, location.Y - 1), pieceColor))
                    {
                        moves.Add(new Point(location.X + 1, location.Y - 1));
                    }
                }
                else if (location.X < board.MaxRow-1 && location.X > 0)
                {
                    if (CanMove(board, new Point(location.X + 1, location.Y)))
                    {
                        moves.Add(new Point(location.X + 1, location.Y));
                    }
                    if (location.Y < board.MaxColumn-1 && CanKnock(board, new Point(location.X + 1, location.Y + 1), pieceColor))
                    {
                        moves.Add(new Point(location.X + 1, location.Y + 1));
                    }
                    if (location.Y > 0 && CanKnock(board, new Point(location.X + 1, location.Y - 1), pieceColor))
                    {
                        moves.Add(new Point (location.X + 1, location.Y - 1));
                    }
                }
            }
            else
            {
                if (location.X == 6)
                {
                    if (CanMove(board, new Point(location.X - 1, location.Y)))
                    {
                        moves.Add(new Point(location.X - 1, location.Y));
                        if (CanMove(board, new Point(location.X - 2, location.Y)))
                        {
                            moves.Add(new Point(location.X - 2, location.Y));
                        }
                    }
                    if (location.Y < board.MaxColumn - 1 && CanKnock(board, new Point(location.X - 1, location.Y + 1), pieceColor))
                    {
                        moves.Add(new Point(location.X - 1, location.Y + 1));
                    }
                    if (location.Y > 0 && CanKnock(board, new Point(location.X - 1, location.Y - 1), pieceColor))
                    {
                        moves.Add(new Point(location.X - 1, location.Y - 1));
                    }
                }
                else if (location.X < board.MaxRow - 1 && location.X > 0)
                {
                    if (CanMove(board, new Point(location.X - 1, location.Y)))
                    {
                        moves.Add(new Point(location.X - 1, location.Y));
                    }
                    if (location.Y < board.MaxColumn - 1 && CanKnock(board, new Point(location.X - 1, location.Y + 1), pieceColor))
                    {
                        moves.Add(new Point(location.X - 1, location.Y + 1));
                    }
                    if (location.Y > 0 && CanKnock(board, new Point(location.X - 1, location.Y - 1), pieceColor))
                    {
                        moves.Add(new Point(location.X - 1, location.Y - 1));
                    }
                }
            }
            return moves;
            }
    }
}