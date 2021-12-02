using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Abstract
{
    public interface IGameRunner
    {
        void Execute(IGameCommand command);
    }
}
