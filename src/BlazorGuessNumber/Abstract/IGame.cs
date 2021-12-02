using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Abstract
{
    public interface IGame
    {
        bool IsRunning { get; set; }
        int Number { get; set; }
        int TurnCount { get; set; }

        List<IGameTurnResult> TurnResults { get; }

    }
}
