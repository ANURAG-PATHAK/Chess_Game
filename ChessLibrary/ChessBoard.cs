using ChessUI;
using System.Collections.Generic;
using System.Drawing;


namespace ChessLibrary
{
    public class ChessBoard
    {
        private readonly Cell[,] _board;
        private readonly CellFactory _factory;
        private bool _isLight;
        public int MaxRow { get; set; }
        public int MaxColumn { get; set; }
        public List<PieceInfo> GameSatate { get; set; }
        public bool IsLight
        {
            get { return _isLight; }
            set
            {
                _isLight = value;
                _factory.CreateCells(this);
            }
        }
        public Cell this[int row, int column]
        {
            get { return _board[row, column]; }
            set { _board[row, column] = value; }
        }
        public Cell this[Point location]
        {
            get { return _board[location.X, location.Y]; }
            set { _board[location.X, location.Y] = value; }
        }
        public ChessBoard()
        {
            _board = new Cell[8, 8];
            MaxColumn = 8;
            MaxRow = 8;
            _isLight = true;
            _factory = new CellFactory();
            _factory.CreateCells(this);
            GameSatate = new List<PieceInfo>();
        }
    }
}