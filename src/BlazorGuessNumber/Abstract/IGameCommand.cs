using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Abstract
{
    public interface IGameCommand
    {
        void Execute(IGame game);
    }
}
