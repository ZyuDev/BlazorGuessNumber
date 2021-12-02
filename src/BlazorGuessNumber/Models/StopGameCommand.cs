using BlazorGuessNumber.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class StopGameCommand : IGameCommand
    {
        public void Execute(IGame game)
        {
            game.IsRunning = false;
            game.TurnCount = 0;
        }
    }
}
