using System.Drawing;

namespace ChessLibrary
{
    public class Cell
    {
        public IPiece Piece { get; set; }
        public bool CellColor { get; set; }
        public Point Location { get; set; }
        public Cell(bool light, Point location)
        {
            CellColor = light;
            Location = location;
        }
    }
}