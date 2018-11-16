﻿



using GalaSoft.MvvmLight.Command;
using Sales.Helpers;
using Sales.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sales.ViewModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        #endregion
        #region Commands
        public ICommand GotoCommand
        {
            get
            {
                return new RelayCommand(GoTo);
            }
        }

        private void GoTo()
        {
            if (this.PageName=="LoginPage")
            {
                Settings.AccesToken = string.Empty;
                Settings.TokenType = string.Empty;
                Settings.IsRemembered = false;

                MainViewModel.Getinstance().Login = new LoginViewModel();
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }


        #endregion
    }
}
