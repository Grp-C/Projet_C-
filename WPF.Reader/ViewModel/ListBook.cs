using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.API;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        public ICommand GoToGenre { get; set; }

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<BookWrapper> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;

        public ListBook()
        {
            ItemSelectedCommand = new RelayCommand(book => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book); });
             //Navigate to List Genre
            GoToGenre = new RelayCommand(book => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListGenre>(); });
        }
    }
}
