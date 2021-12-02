using BlazorGuessNumber.Abstract;
using BlazorGuessNumber.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class LooseTurnResult : BaseTurnResult
    {
        public LooseTurnResult(string message) : base(message)
        {
            _kind = TurnResultKinds.LooseTurnResult;
        }
    }
}
