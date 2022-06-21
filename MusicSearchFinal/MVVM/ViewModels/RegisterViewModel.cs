using MusicSearchFinal.DAL.Entities;
using MusicSearchFinal.MVVM.Commands;
using MusicSearchFinal.MVVM.Models;
using MusicSearchFinal.MVVM.Stores;
using MusicSearchFinal.MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicSearchFinal.MVVM.ViewModels
{
    class RegisterViewModel : ViewModelBase
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
       
        public RegisterViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            
            NavigateToLoginView = new NavigateToLoginView(navigationStore);



            
        }
        public ICommand NavigateToLoginView { get; }

        private ICommand _add = null;
        public ICommand Add
        {

            get
            {
                if (_add == null)
                    _add = new RelayCommand(
                        arg =>
                        {
                            var usr = new Users(6 ,Name, Surname);

                            if (_loginModel.AddUserToDB(usr))
                            {
                                CleanForm();
                                System.Windows.MessageBox.Show("Użytkownik został zarejestrowany! Możesz się zalogować");
                            }
                        }
                        ,
                        arg => (Name != "") && (Surname != "")
                        );


                return _add;
            }

        }

        private void CleanForm()
        {
            Name = "";
            Surname = "";
        }
    }
}

