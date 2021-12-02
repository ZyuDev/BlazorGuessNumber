using BlazorGuessNumber.Abstract;
using BlazorGuessNumber.Enums;
using BlazorGuessNumber.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Pages
{
    public partial class GamePage: ComponentBase
    {

        private GameRunner _runner;
        private int _currentNumber;
        private List<IGameTurnResult> _turnResults = new List<IGameTurnResult>();

        [Inject]
        public IGameSettings Settings { get; set; }

        [Inject]
        public IGame Game { get; set; }

        public string FormTitle
        {
            get
            {
                var title = $"Guess the secret number from [{Settings.MinValue}, {Settings.MaxValue}] by {(Settings.TurnsCount - Game.TurnCount)} steps.";

                return title;
            }
        }

        protected override void OnInitialized()
        {
            _runner = new GameRunner(Game);
        }

        private void OnStartClick()
        {
            var command = new StartGameCommand(Settings);
            _runner.Execute(command);
        }

        private void OnStopClick()
        {
            var command = new StopGameCommand();
            _runner.Execute(command);
        }

        private void OnMakeTurnClick()
        {
            var command = new MakeTurnGameCommand(Settings, _currentNumber);
            _runner.Execute(command);

            var lastResult = Game.TurnResults.LastOrDefault();
            if (lastResult.Kind == TurnResultKinds.LooseTurnResult 
                || lastResult.Kind == TurnResultKinds.WinTurnResult)
            {
                var stopCommand = new StopGameCommand();
                _runner.Execute(stopCommand);
            }
        }

        private string TurnResultClass(IGameTurnResult turnResult)
        {
            switch (turnResult.Kind)
            {
                case Enums.TurnResultKinds.LooseTurnResult:
                    return "list-group-item-danger";
                case Enums.TurnResultKinds.WinTurnResult:
                    return "list-group-item-success";
                case Enums.TurnResultKinds.WrongTurnResult:
                    return "list-group-item-info";
                default:
                    return "list-group-item-info";
            }
        }
    }
}
