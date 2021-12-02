using BlazorGuessNumber.Abstract;
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
            _runner = new GameRunner(Game, Settings);
        }

        private void OnStartClick()
        {
            _runner.Start();
        }

        private void OnStopClick()
        {
            _runner.Stop();
        }

        private void OnMakeTurnClick()
        {
            _runner.MakeTurn(_currentNumber);
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
