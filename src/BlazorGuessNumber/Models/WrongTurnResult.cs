using BlazorGuessNumber.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class WrongTurnResult : BaseTurnResult
    {
        public WrongTurnResult(string message) : base(message)
        {
            _kind = TurnResultKinds.WrongTurnResult;
        }
    }
}
