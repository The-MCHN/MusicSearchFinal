using MusicSearchFinal.MVVM.Stores;
using MusicSearchFinal.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.MVVM.Commands
{
    public class NavigateToRegisterView : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateToRegisterView(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {

            _navigationStore.CurrentViewModel = new RegisterViewModel(_navigationStore);

        }
    }
}
