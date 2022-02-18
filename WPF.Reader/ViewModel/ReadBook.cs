using System.ComponentModel;
using WPF.Reader.API;
using WPF.Reader.Model;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BookWrapper CurrentBook { get; init; }
        public ReadBook(BookWrapper book)
        {
            CurrentBook = book;
        }
        // A vous de jouer maintenant
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
   
}
