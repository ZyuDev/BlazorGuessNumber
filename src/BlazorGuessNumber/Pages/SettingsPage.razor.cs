using BlazorGuessNumber.Abstract;
using BlazorGuessNumber.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGuessNumber.Pages
{
    public partial class SettingsPage: ComponentBase
    {

        private bool _isEditing;
        private IGameSettings _settingsLocal;

        [Inject]
        public IGameSettings Settings { get; set; }

        protected override void OnInitialized()
        {
            _settingsLocal = (GameSettings)((GameSettings)Settings).Clone();
        }

        private void OnEditClick()
        {
            _isEditing = true;
        }

        private void OnCancelClick()
        {
            _isEditing = false;
            _settingsLocal.Update(Settings);
        }

        private void OnOkClick()
        {
            _isEditing = false;
            Settings.Update(_settingsLocal);
        }
    }
}
