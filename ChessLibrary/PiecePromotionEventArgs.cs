using System;

namespace ChessLibrary
{
    public class PiecePromotionEventArgs : EventArgs
    {
        public Cell FinalLocation { get; set; }
    }
}
