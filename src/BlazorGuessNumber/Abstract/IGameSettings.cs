using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Abstract
{
    public interface IGameSettings
    {
        int MinValue { get; set; }
        int MaxValue { get; set; }
        int TurnsCount { get; set; }

        void Update(IGameSettings item);
    }
}
