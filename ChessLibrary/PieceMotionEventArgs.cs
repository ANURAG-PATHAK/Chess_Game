using System;
using System.Drawing;

namespace ChessLibrary
{
    public class PieceMotionEventArgs : EventArgs
    {
        public Cell InitialLocation { get; set; }
        public Cell FinalLocation { get; set; }

    }
}