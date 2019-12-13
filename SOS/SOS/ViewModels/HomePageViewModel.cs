using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SOS.Models.Security;
using Xamarin.Forms;
using PrismAppExample.Messages.Security;
using SOS.Models;

namespace SOS.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private ISecurityService _securityService;
        private IEventAggregator _eventAggregator;

        private DelegateCommand<Models.Security.MenuItem> _navigateCommand;
        private ObservableCollection<Models.Security.MenuItem> _menuItems;
        public ObservableCollection<Models.Security.MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        public DelegateCommand<Models.Security.MenuItem> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<Models.Security.MenuItem>(ExecuteNavigateCommand));

        public async void ExecuteNavigateCommand(Models.Security.MenuItem menu)
        {
            if (menu.MenuType == Enums.Security.MenuTypeEnum.LogOut)
            {
                _securityService.LogOut();
            }
            else
                await NavigationService.NavigateAsync(menu.NavigationPath);

        }

        public HomePageViewModel(INavigationService navigationService, ISecurityService securityService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            Title = "Main Page";

            _securityService = securityService;
            _eventAggregator = eventAggregator;

            MenuItems = new ObservableCollection<Models.Security.MenuItem>(_securityService.GetAllowedAccessItems());

            //_eventAggregator.GetEvent<LoginMessage>().Subscribe(LoginUserEvent);
            _eventAggregator.GetEvent<LogOutMessage>().Subscribe(LogOutEvent);
        }

        private void LoginUserEvent()
        {
            throw new NotImplementedException();
        }

        public void LoginUserEvent(User user)
        {
            MenuItems = new ObservableCollection<Models.Security.MenuItem>(_securityService.GetAllowedAccessItems());

            NavigationService.NavigateAsync("NavigationPage/MapsView");
        }

        public void LogOutEvent()
        {
            MenuItems = new ObservableCollection<Models.Security.MenuItem>(_securityService.GetAllowedAccessItems());

            NavigationService.NavigateAsync("NavigationPage/LoginView");
        }

    }
}
