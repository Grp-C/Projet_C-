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




    }
}
