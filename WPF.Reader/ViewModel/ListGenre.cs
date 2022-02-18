using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.API;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListGenre : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        public ICommand GoToBook { get; set; }
        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().Genres;

        public ListGenre()
        {
            //ItemSelectedCommand = new RelayCommand(genre => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book); });
           GoToBook = new RelayCommand(genre => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListBook>(); });
        }
    }
}
