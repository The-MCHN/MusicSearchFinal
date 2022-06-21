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
    class AddBandViewModel : ViewModelBase
    {
        private Model _model = null;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        private readonly NavigationStore _navigationStore;
        
        private ObservableCollection<Band> _bands;
        public ObservableCollection<Band> Bands
        {
            get
            {
                return _bands;
            }
            set
            {
                _bands = value;
                OnPropertyChanged(nameof(Bands));
            }
        }
        private bool _canAdd;
        public bool CanAdd
        {
            get
            {
                return _canAdd;
            }
            set
            {
                _canAdd = value;
                OnPropertyChanged(nameof(CanAdd));
            }
        }

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

        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        private string _genre;
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        private string _concerts;
        public string Concerts
        {
            get
            {
                return _concerts;
            }
            set
            {
                _concerts = value;
                OnPropertyChanged(nameof(Concerts));
            }
        }
        private Band _currentBand;
        public Band CurrentBand { get; set; }

        public AddBandViewModel(Model model, NavigationStore navigationStore)
        { 
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _model = model;
            _bands = _model.Bands;
            _currentBand = new Band("Zenek", "Polska", "Disco", "Tak");

            NavigateToLoginView = new NavigateToLoginView(navigationStore);
            NavigateToDBPreview = new NavigateToDBGUI(navigationStore);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private ICommand _loadBand = null;
        public ICommand LoadBand
        {

            get
            {
                if (_loadBand == null)
                    _loadBand = new RelayCommand(
                        arg =>
                        {
                            if (CurrentBand != null)
                            {
                                //CurrentBand = _currentBand;
                                Name = CurrentBand.Name;
                                Country = CurrentBand.Country;
                                Genre = CurrentBand.Genre;
                                Concerts = CurrentBand.Concerts;
                                CanAdd = false;
                            }
                            else { CleanForm(); }
                        }
                        ,
                        arg => true
                        );


                return _loadBand;
            }

        }

        private ICommand _add = null;

        public ICommand Add
        {

            get
            {
                if (_add == null)
                    _add = new RelayCommand(
                        arg =>
                        {
                            var band = new Band(Name, Country, Genre, Concerts);

                            if (_model.AddBandToDB(band))
                            {
                                CleanForm();
                                System.Windows.MessageBox.Show("Zespół został dodany do bazy!");
                            }
                        }
                        ,
                        arg => (Name != "") && (Country != "") && (Genre != "") && (Concerts != "")
                        );


                return _add;
            }

        }

        private ICommand _delete = null;

        public ICommand Delete
        {

            get
            {
                if (_delete == null)
                    _delete = new RelayCommand(
                        arg =>
                        {
                            var band = new Band(Name, Country, Genre, Concerts);

                            if (_model.DeleteBandFromDB(band))
                            {
                                CleanForm();
                                System.Windows.MessageBox.Show("Zespół został usunięty!");
                                _currentBand = new Band(Bands.ElementAt(0));
                            }
                        }
                        ,
                        arg => (Name != "") && (Country != "") && (Genre != "") && (Concerts != "")
                        );


                return _delete;
            }

        }

        public ICommand NavigateToDBPreview { get; }
        public ICommand NavigateToLoginView { get; }
        private void CleanForm()
        {
            Name = "";
            Country = "";
            Genre = "";
            Concerts = "";
            CanAdd = true;
            //EdycjaDostepna = false;
        }
    }
}
