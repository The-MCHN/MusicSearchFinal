using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicSearchFinal.MVVM.Commands;
using MusicSearchFinal.MVVM.Models;
using MusicSearchFinal.MVVM.Stores;
using MusicSearchFinal.MVVM.ViewModels.Base;

namespace MusicSearchFinal.MVVM.ViewModels
{

    class LoginViewModel : ViewModelBase
    {
        private LoginModel _loginModel = new LoginModel();
        private readonly NavigationStore _navigationStore;

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        private ObservableCollection<string> _role;
        public ObservableCollection<string> Role
        {
            get
            {
                return _role;
            }
            
        }


        private string _selectedRole;
      

        public string SelectedRole
        {
            get
            {
                return _selectedRole;
            }
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
            }
        }
        public ICommand LoginCommand { get; }
        public ICommand NavigateToDBPreview { get; }
        public ICommand NavigateToRegisterView { get; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            LoginCommand = new LoginCommand(this, navigationStore, _loginModel);
            NavigateToDBPreview = new NavigateToDBGUI(navigationStore);
            NavigateToRegisterView = new NavigateToRegisterView(navigationStore);

            _role = _loginModel.SetRole();
        }
    }
}

