using BlazorGuessNumber.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class Game : IGame
    {
        private IGameSettings _settings;
        private List<IGameTurnResult> _turnResults = new List<IGameTurnResult>();

        public int Number { get; set; }
        public int TurnCount { get; set; }
        public bool IsRunning { get; set; }

        public List<IGameTurnResult> TurnResults => _turnResults;




    }
}
