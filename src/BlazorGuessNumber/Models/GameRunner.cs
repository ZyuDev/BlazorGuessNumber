using BlazorGuessNumber.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class GameRunner
    {
        private IGame _game;
        private IGameSettings _settings;


        public GameRunner(IGame game, IGameSettings settings)
        {
            _game = game;
            _settings = settings;
        }

        public void Start()
        {
            _game.IsRunning = true;
            _game.TurnCount = 0;
            _game.Number = GenerateNumber();
            _game.TurnResults.Clear();
        }

        public void Stop()
        {
            _game.IsRunning = false;
            _game.TurnCount = 0;

        }

        public void MakeTurn(int number)
        {
            IGameTurnResult turnResult;

            _game.TurnCount++;

            if (_game.TurnCount > _settings.TurnsCount)
            {
                turnResult = new LooseTurnResult("You exceed number of turns.");
                Stop();
            }
            else
            {
                if (number > _game.Number)
                {
                    turnResult = new WrongTurnResult($"You number {number} greater then the secret number.");
                }
                else if (number < _game.Number)
                {
                    turnResult = new WrongTurnResult($"You number {number} less then the secret number.");
                }
                else
                {
                    turnResult = new WinTurnResult($"Secret number:{_game.Number}. You win!");
                    Stop();
                }
            } 

            _game.TurnResults.Add(turnResult);

            if (turnResult.Kind == Enums.TurnResultKinds.WrongTurnResult && _game.TurnCount == _settings.TurnsCount)
            {
                var looseResult = new LooseTurnResult("You exceed number of turns.");
                _game.TurnResults.Add(looseResult);
                Stop();
            }
        }

        public int GenerateNumber()
        {
            var rnd = new Random();
            return rnd.Next(_settings.MinValue, _settings.MaxValue);
        }
    }
}
