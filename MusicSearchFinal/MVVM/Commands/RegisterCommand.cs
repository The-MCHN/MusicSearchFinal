using MusicSearchFinal.DAL.Entities;
using MusicSearchFinal.DAL.Repositories;
using MusicSearchFinal.MVVM.Models;
using MusicSearchFinal.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicSearchFinal.MVVM.Commands
{
    class RegisterCommand : ICommand
    {

        private readonly LoginModel _loginModel;
        private readonly RegisterViewModel _viewModel;

        public ICommand NavigateToDBPreview { get; }
        public RegisterCommand(RegisterViewModel viewModel, LoginModel loginModel)
        {
         
            _loginModel = loginModel;
            _viewModel = viewModel;

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

            var usr = new Users(UsersRepository.GetLastID() + 1, _viewModel.Name, _viewModel.Surname);

            if (_loginModel.AddUserToDB(usr))
            {
                _viewModel.CleanForm();
                System.Windows.MessageBox.Show("Użytkownik został zarejestrowany! Możesz się zalogować");
            }
            

        }


        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

