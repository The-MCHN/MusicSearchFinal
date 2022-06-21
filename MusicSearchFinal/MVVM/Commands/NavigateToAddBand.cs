using MusicSearchFinal.MVVM.Models;
using MusicSearchFinal.MVVM.Stores;
using MusicSearchFinal.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.MVVM.Commands
{
    class NavigateToAddBand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateToAddBand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {

            _navigationStore.CurrentViewModel = new AddBandViewModel(new Model(), _navigationStore);

        }
    }
}
