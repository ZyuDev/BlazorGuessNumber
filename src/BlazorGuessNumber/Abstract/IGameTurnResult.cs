using BlazorGuessNumber.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Abstract
{
    public interface IGameTurnResult
    {
        string Message { get; }

        TurnResultKinds Kind { get; }
        
    }
}
