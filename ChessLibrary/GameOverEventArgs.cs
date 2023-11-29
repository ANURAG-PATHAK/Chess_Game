using System;

namespace ChessLibrary
{
    public class GameOverEventArgs : EventArgs
    {
        public bool Winner { get; set; }
    }
}