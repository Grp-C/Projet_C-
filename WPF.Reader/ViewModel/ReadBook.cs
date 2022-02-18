using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using WPF.Reader.API;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Book CurrentBook { get; init; }
        public ReadBook(BookWrapper book)
        {
            CurrentBook = Ioc.Default.GetRequiredService<LibraryService>().getBooksbyid(book.Id); ;
        }
        // A vous de jouer maintenant
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook() : base(new BookWrapper())
        {
        }
    }
}
