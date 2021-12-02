using BlazorGuessNumber.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Models
{
    public class MakeTurnGameCommand : IGameCommand
    {

        private IGameSettings _settings;
        private int _number;

        public MakeTurnGameCommand(IGameSettings settings, int number)
        {
            _settings = settings;
            _number = number;
        }

        public void Execute(IGame game)
        {
            IGameTurnResult turnResult;

            game.TurnCount++;

            if (game.TurnCount > _settings.TurnsCount)
            {
                turnResult = new LooseTurnResult("You exceed number of turns.");
            }
            else
            {
                if (_number > game.Number)
                {
                    turnResult = new WrongTurnResult($"You number {_number} greater then the secret number.");
                }
                else if (_number < game.Number)
                {
                    turnResult = new WrongTurnResult($"You number {_number} less then the secret number.");
                }
                else
                {
                    turnResult = new WinTurnResult($"Secret number:{game.Number}. You win!");
                }
            }

            game.TurnResults.Add(turnResult);

            if (turnResult.Kind == Enums.TurnResultKinds.WrongTurnResult && game.TurnCount == _settings.TurnsCount)
            {
                var looseResult = new LooseTurnResult("You exceed number of turns.");
                game.TurnResults.Add(looseResult);
            }
        }
    }
}
