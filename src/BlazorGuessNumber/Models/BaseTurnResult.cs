using BlazorGuessNumber.Abstract;
using BlazorGuessNumber.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public abstract class BaseTurnResult : IGameTurnResult
    {
        protected TurnResultKinds _kind;

        public string Message { get; }

        public virtual TurnResultKinds Kind => _kind;

        public BaseTurnResult(string message)
        {
            Message = message;
        }
    }
}
