﻿using Prism.Navigation;
using System.Windows.Input;
using ToDoMe.Views;
using Xamarin.Forms;

namespace ToDoMe.ViewModels
{
    public class WelcomePageViewModel: BaseViewModel
    {
        #region Commands

        public ICommand GetStartedCommand { get; set; }

        #endregion

        #region Constructors

        public WelcomePageViewModel(
            INavigationService navigationService) : base(navigationService)
        { 
            GetStartedCommand = new Command(GetStartedCommandHandler);
        }

        #endregion

        #region Command Handlers

        private async void GetStartedCommandHandler()
        {
            await _navigationService.NavigateAsync(nameof(AuthPage));
        }

        #endregion
    }
}
