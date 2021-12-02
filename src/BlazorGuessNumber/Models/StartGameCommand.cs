using BlazorGuessNumber.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class StartGameCommand : IGameCommand
    {
        IGameSettings _settings;
        public StartGameCommand(IGameSettings settings)
        {
            _settings = settings;
        }

        public void Execute(IGame game)
        {
            game.IsRunning = true;
            game.TurnCount = 0;
            game.Number = GenerateNumber();
            game.TurnResults.Clear();
        }

        public int GenerateNumber()
        {
            var rnd = new Random();
            return rnd.Next(_settings.MinValue, _settings.MaxValue);
        }
    }
}
