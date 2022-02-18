using System;
using System.Collections.ObjectModel;
using WPF.Reader.API;

namespace WPF.Reader.Service
{
    public class LibraryService
    {   
        public LibraryService()
        {
            getBooks();
            getGenres();
            
        }
        String URL = "https://localhost:5001/";
        public ObservableCollection<BookWrapper> Books { get; set; } = new ObservableCollection<BookWrapper>() {
            };
       
        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>() {

        };




        public async void getBooks()
        {
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
            var books = await client.ApiBookGetBooksAsync(null, 5, null);
            Books.Clear();
            foreach (BookWrapper book in books)
            {
                Books.Add(book);
            }
        }
        public  Book getBooksbyid(int id)
        {
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
            var books = client.ApiBookGetBookByIdAsync(id);
            return books.Result;
            
            
        }
        public async void getGenres()
        {
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
            var genres = await client.ApiGenreGetGenresAsync();
            Genres.Clear();
            foreach (Genre genre in genres)
            {
                Genres.Add(genre);
            }
        }

        public System.Collections.Generic.ICollection<BookWrapper> getBooksbygenres(int? id=0)
        {
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
            var books =  client.ApiBookGetBooksAsync(id, 5, null);
            return books.Result;
        }

        // C'est aussi ici que vous ajouterez les requète réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouer et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
    }
}
