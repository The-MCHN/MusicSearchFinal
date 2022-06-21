using MusicSearchFinal.DAL.Entities;
using MusicSearchFinal.MVVM.Commands;
using MusicSearchFinal.MVVM.Models;
using MusicSearchFinal.MVVM.Stores;
using MusicSearchFinal.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusicSearchFinal.MVVM.ViewModels
{
    class ListViewModel : ViewModelBase
    {

        private Model _model = null;

        #region switching between Views
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        #endregion

        #region properties
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

        private ObservableCollection<Members> _members;
        public ObservableCollection<Members> Members
        {
            get
            {
                return _members;
            }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }
        private ObservableCollection<Album> _albums;
        public ObservableCollection<Album> Albums
        {
            get
            {
                return _albums;
            }
            set
            {
                _albums = value;
                OnPropertyChanged(nameof(Albums));
            }
        }
        private ObservableCollection<Song> _songs;
        public ObservableCollection<Song> Songs
        {
            get
            {
                return _songs;
            }
            set
            {
                _songs = value;
                OnPropertyChanged(nameof(Songs));
            }
        }

        #endregion

        public ListViewModel(Model model, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _model = model;
            
            _bands = model.Bands;
            _albums = model.Albums;
            _songs = model.Songs;

            NavigateToAddBandView = new NavigateToAddBand(navigationStore);
            NavigateToLoginView = new NavigateToLoginView(navigationStore);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public Band CurrentBand { get; set; }
        public Album CurrentAlbum { get; set; }
        public Members CurrentMember { get; set; }
        public Song CurrentSong { get; set; }

        #region commands
        private ICommand _loadBands = null;
        public ICommand LoadBands
        {
            get
            {
                if (_loadBands == null)
                    _loadBands = new RelayCommand(
                        arg => {
                            if (CurrentMember != null)
                                Bands = _model.GetBandOfMember(CurrentMember);
                        },
                        arg => true
                        );

                return _loadBands;
            }
        }

        private ICommand _loadAllBands= null;
        public ICommand LoadAllBands
        {
            get
            {
                if (_loadAllBands == null)
                    _loadAllBands = new RelayCommand(
                        arg => {
                            
                                Bands = _model.Bands;
                        },
                        arg => true
                        );

                return _loadAllBands;
            }
        }

        private ICommand _loadMembers = null;
        public ICommand LoadMembers
        {
            get
            {
                if (_loadMembers == null)
                    _loadMembers = new RelayCommand(
                        arg => {
                            if (CurrentBand != null)
                                Members = _model.GetBandsMembers(CurrentBand);
                        },
                        arg => true
                        );

                return _loadMembers;
            }
        }

        private ICommand _loadAllMembers = null;
        public ICommand LoadAllMembers
        {
            get
            {
                if (_loadAllMembers == null)
                    _loadAllMembers = new RelayCommand(
                        arg => {

                            Members = _model.Members;
                        },
                        arg => true
                        );

                return _loadAllMembers;
            }
        }

        private ICommand _loadAlbums = null;
        public ICommand LoadAlbums
        {
            get
            {
                if (_loadAlbums == null)
                    _loadAlbums = new RelayCommand(
                        arg => {
                            if (CurrentAlbum != null)
                                Albums = _model.GetAllBandAlbums(CurrentBand);
                        },
                        arg => true
                        );

                return _loadAlbums;
            }
        }

        private ICommand _loadAllAlbums = null;
        public ICommand LoadAllAlbums
        {
            get
            {
                if (_loadAllAlbums == null)
                    _loadAllAlbums = new RelayCommand(
                        arg => {
                                Albums = _model.Albums;
                        },
                        arg => true
                        );

                return _loadAllAlbums;
            }
        }

        private ICommand _loadAlbumSongs = null;
        public ICommand LoadAlbumSongs
        {
            get
            {
                if (_loadAlbumSongs == null)
                    _loadAlbumSongs = new RelayCommand(
                        arg => {
                                Songs = _model.GetSongsFromAlbum(CurrentAlbum);
                        },
                        arg => true
                        );

                return _loadAlbumSongs;
            }
        }

        private ICommand _loadAllSongs = null;
        public ICommand LoadAllSongs
        {
            get
            {
                if (_loadAllSongs == null)
                    _loadAllSongs = new RelayCommand(
                        arg => {
                                Songs = _model.Songs;
                        },
                        arg => true
                        );

                return _loadAllSongs;
            }
        }

        public ICommand NavigateToAddBandView { get; }
        public ICommand NavigateToLoginView { get; }

        #endregion
    }
}
