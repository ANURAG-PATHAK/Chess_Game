using System.Drawing;

namespace ChessLibrary
{
    public class CellFactory
    {
        public void CreateCells(ChessBoard board)
        {
            bool light = true;
            for (int row = 0; row < board.MaxRow; row++)
            {
                for (int column = 0; column < board.MaxColumn; column++)
                {
                    light = !light;
                    board[row, column] = new Cell(light, new Point(row, column));
                }
                light = board[row, 0].CellColor;
            }
        }
    }
}