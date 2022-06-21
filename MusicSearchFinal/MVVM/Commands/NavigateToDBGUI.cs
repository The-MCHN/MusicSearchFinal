using MusicSearchFinal.MVVM.Models;
using MusicSearchFinal.MVVM.Stores;
using MusicSearchFinal.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicSearchFinal.MVVM.Commands
{
    public class NavigateToDBGUI : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateToDBGUI(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            
            _navigationStore.CurrentViewModel = new ListViewModel(new Model(),_navigationStore);
                        
        }
    }
}
