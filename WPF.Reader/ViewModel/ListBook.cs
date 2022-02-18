using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.Generic;
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
        public ICollection<BookWrapper> Items;
        public ObservableCollection<BookWrapper> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;
        public ListBook()
                    {
            ItemSelectedCommand = new RelayCommand(book => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book); });
            
            Items = Ioc.Default.GetRequiredService<LibraryService>().getBooksbygenres(null);
            Books.Clear();
            foreach (var item in Items) {
               
                Books.Add(item); } 
            GoToGenre = new RelayCommand(book => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListGenre>(); });
        }
    }
}
