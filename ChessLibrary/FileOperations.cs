using ChessUI;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ChessLibrary
{
    internal class FileOperations
    {
        public static void EraseFile(string file)
        {
            if(File.Exists(file)) 
            {
                File.Delete(file);
            }
        }
        public static GameStateInformation ReadFile(string file)
        {
            GameStateInformation gameState = new GameStateInformation();
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                gameState = JsonConvert.DeserializeObject<GameStateInformation>(json);
            }
            return gameState;
        }
        public static void WriteFile(string file, GameStateInformation gameState)
        {
            string jsonString = JsonConvert.SerializeObject(gameState);
            using (StreamWriter streamWriter = new StreamWriter(file))
            {
                streamWriter.Write(jsonString);
                streamWriter.Flush();
            }
        }
    }
}
