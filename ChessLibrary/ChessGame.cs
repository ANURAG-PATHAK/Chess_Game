using ChessUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ChessLibrary
{
    public class ChessGame
    {
        public ChessBoard Board;
        public bool CurrentPlayer;
        public event EventHandler<PiecePromotionEventArgs> PiecePromoted;
        public event EventHandler<PieceMotionEventArgs> PieceMoved;
        public event EventHandler<GameOverEventArgs> GameOver;
        public ChessGame(bool currentPlayer = true)
        {
            Board = new ChessBoard();
            CurrentPlayer = currentPlayer;
        }
        public void LoadGame(string file)
        {
            if (File.Exists(file))
            {
                GameStateInformation gameState = FileOperations.ReadFile(file);
                CurrentPlayer = gameState.CurrentPlayer;
                PlacePieces(gameState.PieceInfo);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        public void SaveGame(string file)
        {
            GameStateInformation gameStateInformation = new GameStateInformation();
            List<PieceInfo> pieceInfoList = new List<PieceInfo>();
            for (int i = 0; i < Board.MaxRow; i++)
            {
                for (int j = 0; j < Board.MaxColumn; j++)
                {
                    if (Board[i, j].Piece != null)
                    {
                        PieceInfo pieceInfo = new PieceInfo
                        {
                            Name = Board[i, j].Piece.ToString(),
                            Location = $"{i},{j}",
                            Color = Board[i, j].Piece.PieceColor == Board.IsLight ? "Light" : "Dark",
                        };
                        pieceInfoList.Add(pieceInfo);
                    }
                }
            }
            gameStateInformation.PieceInfo = pieceInfoList;
            gameStateInformation.CurrentPlayer = CurrentPlayer;
            FileOperations.WriteFile(file, gameStateInformation);
        }
        public void EraseFile(string file)
        {
            FileOperations.EraseFile(file);
        }
        private bool CheckForPromotion(Cell cell)
        {
            return (cell.Location.X == 7 && cell.Piece.ToString() == "ChessLibrary.Pawn" && cell.Piece.PieceColor) || (cell.Location.X == 0 && cell.Piece.ToString() == "ChessLibrary.Pawn" && !cell.Piece.PieceColor);
        }
        public void MovePiece(Cell initialCell, Cell targetCell)
        {
            if (initialCell.Piece.Behavior.GetAllMoves(Board, initialCell.Location, initialCell.Piece.PieceColor).Contains(targetCell.Location))
            {
                targetCell.Piece = initialCell.Piece;
                initialCell.Piece = null;
                if (CheckForPromotion(targetCell))
                {
                    PiecePromotionEvent(new PiecePromotionEventArgs { FinalLocation = targetCell });
                }
                else
                {
                    PieceMotionEvent(new PieceMotionEventArgs { InitialLocation = initialCell, FinalLocation = targetCell });
                }
                if (targetCell.Piece != null && targetCell.Piece.ToString() == "ChessLibrary.King")
                {
                    GameOverEvent(new GameOverEventArgs { Winner = initialCell.Piece.PieceColor });
                }
            }
        }
        protected virtual void PiecePromotionEvent(PiecePromotionEventArgs e)
        {
            PiecePromoted?.Invoke(this, e);
        }
        protected virtual void PieceMotionEvent(PieceMotionEventArgs e)
        {
            PieceMoved?.Invoke(this, e);
        }
        protected virtual void GameOverEvent(GameOverEventArgs e)
        {
            GameOver?.Invoke(this, e);
        }
        private void PlacePieces(List<PieceInfo> pieceInfo)
        {
            foreach (PieceInfo piece in pieceInfo)
            {
                string[] coordinate = piece.Location.Split(',');
                Point location = new Point(int.Parse(coordinate[0]), int.Parse(coordinate[1]));
                switch (piece.Name)
                {
                    case "ChessLibrary.Pawn":
                        Board[location].Piece = new Pawn(piece.Color == "Light");
                        break;
                    case "ChessLibrary.Rook":
                        Board[location].Piece = new Rook(piece.Color == "Light");
                        break;
                    case "ChessLibrary.Knight":
                        Board[location].Piece = new Knight(piece.Color == "Light");
                        break;
                    case "ChessLibrary.King":
                        Board[location].Piece = new King(piece.Color == "Light");
                        break;
                    case "ChessLibrary.Queen":
                        Board[location].Piece = new Queen(piece.Color == "Light");
                        break;
                    case "ChessLibrary.Bishop":
                        Board[location].Piece = new Bishop(piece.Color == "Light");
                        break;
                }
            }
        }
    }
}