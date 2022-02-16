using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ASP.Server.Models;

namespace ASP.Server.Controllers
{
    
     

    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Book>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Book> ListBooks = libraryDbContext.Books.Include(book => book.Genres).ToList();
            return View(ListBooks);
        }


        public ActionResult<BookModel> Create(BookModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                List<Genre> genres = libraryDbContext.Genre.Where(genre=>book.Genres.Contains(genre.Id)).ToList();
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Book() { Author=book.Author,Name=book.Name,Price=book.Price,Content=book.Content,Genres=genres});
                libraryDbContext.SaveChanges();
                return RedirectToAction("List");
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new BookModel() { AllGenres = libraryDbContext.Genre.ToList() } );
        }

        public ActionResult Delete(int id)
        {
            Book book = libraryDbContext.Books.Find(id);

            // delete book from the database whose id matches with specified id
            libraryDbContext.Books.Remove(book);
            libraryDbContext.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult<Book> Read(int id)
        {
            Book book = libraryDbContext.Books.Include(book => book.Genres).Where(book => book.Id == id).FirstOrDefault();
            BookModel bookModel = new BookModel()
            {
                Author = book.Author,
                Name = book.Name,
                Price = book.Price,
                Content = book.Content,
                AllGenres=book.Genres.ToList(),
            };
            
            return View(bookModel); 
            
            
        }




        public ActionResult<BookModel> Edit( BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                Book book = libraryDbContext.Books.Include(book => book.Genres).Where(book => book.Id == bookModel.Id).FirstOrDefault();
                book.Name = bookModel.Name;
                book.Price = bookModel.Price;
                //book.Genres = bookModel.Genres.Select(genre => new Genre() { Id = book.Id, Name = book.Name }).ToList();
                book.Author = bookModel.Author;
                book.Content = bookModel.Content;

                libraryDbContext.SaveChanges();

                return RedirectToAction("List");

            }
            else
            {
                Book book = libraryDbContext.Books.Include(book => book.Genres).Where(book => book.Id == bookModel.Id).FirstOrDefault();
                BookModel bookModel1 = new BookModel()
                {
                    Name = book.Name,
                    Price = book.Price,
                    Author = book.Author,
                    Content = book.Content,
                   // Genres = book.Genres.Select(genre => new GenreModel() { Id = book.Id, Name = book.Name }).ToList()
                };
                return View(bookModel1);
            }
            
  
            
        }
    }
}
