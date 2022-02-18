using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.API;
using WPF.Reader.Service;
using System.Collections.Generic;

namespace WPF.Reader.ViewModel
{
        internal class ListBookGenre : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public ICommand ItemSelectedCommand { get; set; }
        public ObservableCollection<BookWrapper> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;
        public ICollection <BookWrapper> Items;
        

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!

        public ListBookGenre(Genre genre)
            {
                ItemSelectedCommand = new RelayCommand(book => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book); });
            
            Items = Ioc.Default.GetRequiredService<LibraryService>().getBooksbygenres(genre.Id);
            Books.Clear();
            foreach (var item in Items) {
               
                Books.Add(item); } 
            
        }
        }
    }
