using BlazorGuessNumber.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class GameSettings: IGameSettings, ICloneable
    {
        public int MinValue { get; set; } = 0;
        public int MaxValue { get; set; } = 100;
        public int TurnsCount { get; set; } = 10;

        public GameSettings()
        {

        }

        public GameSettings(IGameSettings settings)
        {
            Update(settings);   
        }

        public void Update(IGameSettings settings)
        {
            MinValue = settings.MinValue;
            MaxValue = settings.MaxValue;
            TurnsCount = settings.TurnsCount;
        }

        public override string ToString()
        {
            return $"{TurnsCount} turns in [{MinValue}, {MaxValue}]";
        }

        public object Clone()
        {
            var clone = new GameSettings(this);

            return clone;
        }
    }
}
