using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.API;
using WPF.Reader.Service;


namespace WPF.Reader.ViewModel
{
    public class DetailsBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ReadCommand { get; set; }
        // n'oublier pas faire de faire le binding dans DetailsBook.xaml !!!!
        public BookWrapper  CurrentBook { get; init; }

        public DetailsBook(BookWrapper book)
        {
            CurrentBook = book;
            ReadCommand = new RelayCommand(Contenu => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ReadBook>(book); });
        }
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
   
}
