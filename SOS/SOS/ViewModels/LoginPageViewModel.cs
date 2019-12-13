using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOS.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private INavigationService _navigationService;
        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateLoginCommand));

        private async void ExecuteNavigateLoginCommand()
        {
            await _navigationService.NavigateAsync("HomePage/NavigationPage");
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            Title = "LoginPage";
            _navigationService = navigationService;

        }
    }
}
