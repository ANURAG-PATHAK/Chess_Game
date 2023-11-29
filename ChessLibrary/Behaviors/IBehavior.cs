using System.Collections.Generic;
using System.Drawing;

namespace ChessLibrary
{
    public interface IBehavior
    {
        /// <summary>
        /// Gives all the possible moves for a piecce
        /// </summary>
        /// <param name="board"></param>
        /// <param name="location"></param>
        /// <param name="pieceColor"></param>
        /// <returns>List of all points this piece can move to</returns>
        List<Point> GetAllMoves(ChessBoard board,  Point location, bool pieceColor);
    }
}