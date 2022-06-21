using MusicSearchFinal.DAL.Entities;
using MusicSearchFinal.DAL.Repositories;
using MusicSearchFinal.MVVM.Models;
using MusicSearchFinal.MVVM.Stores;
using MusicSearchFinal.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MusicSearchFinal.MVVM.Commands
{
    class LoginCommand : ICommand
    {
        private readonly LoginViewModel _viewModel;
        private readonly NavigationStore _navigationStore;
        private readonly LoginModel _loginModel;

        public ICommand NavigateToDBPreview { get; }
        public LoginCommand(LoginViewModel viewModel, NavigationStore navigationStore, LoginModel loginModel)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
            _loginModel = loginModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
        
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Name) &&
                !string.IsNullOrEmpty(_viewModel.Surname);
        }

        public void Execute(object parameter)
        {

            if (_loginModel.IsUserInRepo(_viewModel.Name.Replace("-", "‌​"), _viewModel.Surname.Replace("-", "‌​")))
            {
                MessageBox.Show($"Success", "Info",
               MessageBoxButton.OK, MessageBoxImage.Information);
                _navigationStore.CurrentViewModel = new ListViewModel(new Model(), _navigationStore);
            }
            else
            {
                MessageBox.Show($"Zarejestruj się!", "Info",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }




        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
