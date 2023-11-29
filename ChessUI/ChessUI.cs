using ChessLibrary;
using ChessUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChessUI
{
    public partial class ChessUI : Form
    {
        private PictureBox[,] _pictureBoxes;
        private List<Point> _listOfMoves;
        private Cell _parentCell;
        private PictureBox _parentPictureBox;
        private Timer _timer;
        private int _height;
        private MenuStrip _menuStrip;
        private ToolStripItem _newGame;
        private ToolStripItem _continueOldGame;
        private ToolStripItem _exitWithoutSaving;
        private ToolStripItem _saveAndExit;
        private ToolStripItem _eraseGameData;
        private string _gameFile;
        private ChessGame _chessGame;
        private Color _light;
        private Color _dark;
        public ChessUI()
        {
            ResetGame();
            InitializeTimer();
            _light = Color.WhiteSmoke;
            _dark = Color.DarkGray;
            _gameFile = Resources.FileContainingNewGameData;
            _pictureBoxes = new PictureBox[8, 8];
            _listOfMoves = new List<Point>();
            _height = 50;
            InitializeMenu(_height);
            InitializeBoard(_height);
        }
        private void InitializeTimer()
        {
            _timer = new Timer
            {
                Interval = 1_00_000
            };
            _timer.Start();
            _timer.Tick += SaveState;
        }
        private void ResetGame()
        {
            _chessGame = new ChessGame();
            _chessGame.GameOver += GameOver;
            _chessGame.PieceMoved += MovePiece;
            _chessGame.PiecePromoted += PromotePiece;
        }
        private void SaveState(object state, EventArgs e)
        {
            _chessGame.SaveGame(Resources.FileContainingGameData);
        }
        private void StartNewGame(object sender, EventArgs e)
        {
            Controls.Clear();
            ResetGame();
            _gameFile = Resources.FileContainingNewGameData;
            InitializeMenu(_height);
            InitializeBoard(_height);
        }
        private void ClearGameData(object sender, EventArgs e)
        {
            _chessGame.EraseFile(Resources.FileContainingGameData);
            Close();
        }
        private void ContinueOldGame(object sender, EventArgs e)
        {
            if (File.Exists(Resources.FileContainingGameData))
            {
                Controls.Clear();
                ResetGame();
                _gameFile = Resources.FileContainingGameData;
                InitializeMenu(_height);
                InitializeBoard(_height);
            }
            else
            {
                MessageBox.Show(Resources.EmptyGameDataMessage);
            }
        }
        public string LoadImage(string pieceName, bool color)
        {
            string assetsFolderPath = Path.Combine(Application.StartupPath, "Assets");
            switch (pieceName)
            {
                case "ChessLibrary.Pawn":
                    return color ? Path.Combine(assetsFolderPath, "LPawn.png") : Path.Combine(assetsFolderPath, "DPawn.png");
                case "ChessLibrary.Rook":
                    return color ? Path.Combine(assetsFolderPath, "LRook.png") : Path.Combine(assetsFolderPath, "DRook.png");
                case "ChessLibrary.Knight":
                    return color ? Path.Combine(assetsFolderPath, "LKnight.png") : Path.Combine(assetsFolderPath, "DKnight.png");
                case "ChessLibrary.King":
                    return color ? Path.Combine(assetsFolderPath, "LKing.png") : Path.Combine(assetsFolderPath, "DKing.png");
                case "ChessLibrary.Queen":
                    return color ? Path.Combine(assetsFolderPath, "LQueen.png") : Path.Combine(assetsFolderPath, "DQueen.png");
                case "ChessLibrary.Bishop":
                    return color ? Path.Combine(assetsFolderPath, "LBishop.png") : Path.Combine(assetsFolderPath, "DBishop.png");
                default:
                    return null;
            }
        }
        private void ExitWithoutSaving(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveAndExit(object sender, EventArgs e)
        {
            _chessGame.SaveGame(Resources.FileContainingGameData);
            Close();
        }
        private void EraseData(object sender, EventArgs e)
        {
            _chessGame.EraseFile(Resources.FileContainingGameData);
        }
        private void InitializeMenu(int height)
        {
            ClientSize = new Size(height * _chessGame.Board.MaxRow, (height * _chessGame.Board.MaxColumn) + 25);
            CenterToScreen();
            Name = "ChessUI";
            Text = Resources.Chess;
            BackColor = Color.Gray;
            _menuStrip = new MenuStrip();
            _newGame = new ToolStripMenuItem()
            {
                Size = new Size(0, 20),
                Text = Resources.NewGame
            };
            _newGame.Click += StartNewGame;
            _continueOldGame = new ToolStripMenuItem()
            {
                Size = new Size(0, 20),
                Text = Resources.ContinueGame
            };
            _continueOldGame.Click += ContinueOldGame;
            _exitWithoutSaving = new ToolStripMenuItem()
            {
                Size = new Size(0, 20),
                Text = Resources.ExitGame
            };
            _exitWithoutSaving.Click += ExitWithoutSaving;
            _saveAndExit = new ToolStripMenuItem()
            {
                Size = new Size(0, 20),
                Text = Resources.SaveGame
            };
            _saveAndExit.Click += SaveAndExit;
            _eraseGameData = new ToolStripMenuItem()
            {
                Size = new Size(0, 20),
                Text = Resources.EraseData
            };
            _eraseGameData.Click += EraseData;
            _menuStrip.Items.AddRange(new ToolStripItem[] { _newGame, _continueOldGame, _saveAndExit, _eraseGameData, _exitWithoutSaving, });
            Controls.Add(_menuStrip);
        }
        private void InitializeBoard(int height)
        {
            _chessGame.LoadGame(_gameFile);
            for (int row = 0; row < _chessGame.Board.MaxRow; row++)
            {
                for (int column = 0; column < _chessGame.Board.MaxColumn; column++)
                {
                    Cell cell = _chessGame.Board[row, column];
                    _pictureBoxes[row, column] = new PictureBox
                    {
                        Location = new Point((height * column), 24 + (height * row)),
                        Size = new Size(height, height),
                        BackColor = cell.CellColor ? _light : _dark,
                        SizeMode = PictureBoxSizeMode.CenterImage,
                        Tag = new Point(row, column),
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    if (cell.Piece != null)
                    {
                        _pictureBoxes[row, column].ImageLocation = LoadImage(cell.Piece.ToString(), cell.Piece.PieceColor);
                        _pictureBoxes[row, column].Click += OnClickShowMoves;
                    }
                    Controls.Add(_pictureBoxes[row, column]);
                }
            }
        }
        private void PromotePiece(object sender, PiecePromotionEventArgs e)
        {
            string path = GetPromotedPiece(_chessGame.CurrentPlayer);
            PictureBox childPictureBox = _pictureBoxes[e.FinalLocation.Location.X, e.FinalLocation.Location.Y];
            childPictureBox.ImageLocation = LoadImage(path, _chessGame.CurrentPlayer);
            _parentPictureBox.Image = null;
            _chessGame.CurrentPlayer = !_chessGame.CurrentPlayer;
            childPictureBox.Click += OnClickShowMoves;
        }
        private void OnClickShowMoves(object sender, EventArgs eventArgs)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Point loc = (Point)pictureBox.Tag;
            Cell cell = _chessGame.Board[loc];
            foreach (Point location in _listOfMoves)
            {
                _pictureBoxes[location.X, location.Y].BackColor = _chessGame.Board[location.X, location.Y].CellColor ? _light : _dark;
                _pictureBoxes[location.X, location.Y].Click -= OnClickMovePiece;
            }
            if (cell.Piece != null)
            {
                if (_chessGame.CurrentPlayer == cell.Piece.PieceColor)
                {
                    _listOfMoves = cell.Piece.Behavior.GetAllMoves(_chessGame.Board, loc, cell.Piece.PieceColor);
                    foreach (Point location in _listOfMoves)
                    {
                        if (_pictureBoxes[location.X, location.Y].Image != null)
                        {
                            _pictureBoxes[location.X, location.Y].BackColor = Color.IndianRed;
                        }
                        else
                        {
                            _pictureBoxes[location.X, location.Y].BackColor = Color.LightGreen;
                        }
                        _parentCell = cell;
                        _parentPictureBox = pictureBox;
                        _pictureBoxes[location.X, location.Y].Click += OnClickMovePiece;
                    }
                }
            }
        }
        private void OnClickMovePiece(object sender, EventArgs e)
        {
            PictureBox childPictureBox = (PictureBox)sender;
            Point location = (Point)childPictureBox.Tag;
            Cell childCell = _chessGame.Board[location];
            if (_parentCell.Piece != null)
            {
                foreach (Point coordinates in _listOfMoves)
                {
                    _pictureBoxes[coordinates.X, coordinates.Y].Click -= OnClickMovePiece;
                    _pictureBoxes[coordinates.X, coordinates.Y].BackColor = _chessGame.Board[coordinates.X, coordinates.Y].CellColor ? _light : _dark;
                }
                _chessGame.MovePiece(_parentCell, childCell);
            }
        }
        private void GameOver(object sender, GameOverEventArgs e)
        {
            MessageBox.Show(string.Format(Resources.Winner, e.Winner));
        }
        private void MovePiece(object sender, PieceMotionEventArgs e)
        {
            PictureBox childPictureBox = _pictureBoxes[e.FinalLocation.Location.X, e.FinalLocation.Location.Y];
            childPictureBox.Image = _parentPictureBox.Image;
            _parentPictureBox.Image = null;
            _chessGame.CurrentPlayer = !_chessGame.CurrentPlayer;
            childPictureBox.Click += OnClickShowMoves;
        }
        private string GetPromotedPiece(bool pieceColor)
        {
            PromotionDialogue dialogue = new PromotionDialogue(pieceColor);
            dialogue.ShowDialog();
            return dialogue.Piece;
        }
    }
}