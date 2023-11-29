using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ChessUI
{
    public class GameStateInformation
    {
        public bool CurrentPlayer;
        public List<PieceInfo> PieceInfo;
    }
}