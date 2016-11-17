using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutDomain.GameLogicCreator
{
    public class GameLogicCreator
    {
        private class Level
        {
            public string name { get; set; }
            public int columns { get; set; }
            public int rows { get; set; }
            public int[] on { get; set; }
        }
        
        public static IReadOnlyCollection<GameLogic> CreateFromUri(IHttpDownloader httpDownloader, string remoteUri)
        {
            var levelsString = httpDownloader.GetData(remoteUri);
            var levels = Newtonsoft.Json.JsonConvert.DeserializeObject<Level[]>(levelsString);
            var gameLogicLevels = new List<GameLogic>();
            foreach(var level in levels)
            {
                var gameLogic = new GameLogic();
                gameLogic.LoadLevel(level.name, level.columns, level.rows, level.on);
                gameLogicLevels.Add(gameLogic);
            }
            return gameLogicLevels.AsReadOnly();
        } 
    }
}
