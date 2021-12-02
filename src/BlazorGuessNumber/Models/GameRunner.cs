using BlazorGuessNumber.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class GameRunner: IGameRunner
    {
        private IGame _game;

        public GameRunner(IGame game)
        {
            _game = game;
        }

        public void Execute(IGameCommand command)
        {
            command.Execute(_game);
        }
       
    }
}
