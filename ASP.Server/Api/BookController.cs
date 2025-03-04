﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;

namespace ASP.Server.Api
{

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        // Methode a ajouter : 
        // - GetBooks
        //   - Entrée: Optionel -> Liste d'Id de genre, limit -> defaut à 10, offset -> défaut à 0
        //     Le but de limit et offset est dé créer un pagination pour ne pas retourner la BDD en entier a chaque appel
        //   - Sortie: Liste d'object contenant uniquement: Auteur, Genres, Titre, Id, Prix
        //     la liste restourner doit être compsé des élément entre <offset> et <offset + limit>-
        //     Dans [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20] si offset=8 et limit=5, les élément retourner seront : 8, 9, 10, 11, 12

        // - GetBook
        //   - Entrée: Id du livre
        //   - Sortie: Object livre entier

        // - GetGenres
        //   - Entrée: Rien
        //   - Sortie: Liste des genres

        // Aide:
        // Pour récupéré un objet d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.First()
        // Pour récupéré des objets d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.ToList()
        // Pour faire une requète avec filtre:
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Skip().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Take().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Where(x => x == y).<Selecteurs>
        // Pour récupérer une 2nd table depuis la base:
        //   - .Include(x => x.yyyyy)
        //     ou yyyyy est la propriété liant a une autre table a récupéré
        //
        // Exemple:
        //   - Ex: libraryDbContext.MyObjectCollection.Include(x => x.yyyyy).Where(x => x.yyyyyy.Contains(z)).Skip(i).Take(j).ToList()


        // Get all books by genreId (optionnel) and limit and offset  and return BookWrapper( id , Name , Price , Author)
        public ActionResult<List<BookWrapper>> GetBooks( int genreId, int limit=10, int offset=0 )
        {
            return genreId!=0 ? libraryDbContext.Books.Include(book => book.Genres).Select(book => new BookWrapper() { Id = book.Id,Name = book.Name,Author = book.Author, Price = book.Price , Genres = book.Genres}).Where(book => book.Genres.Contains(new Genre { Id = genreId })).OrderBy(q => q.Id).Skip(offset - 1).Take(limit).ToList()
            : libraryDbContext.Books.Include(book => book.Genres).Select(book => new BookWrapper() { Id = book.Id, Name = book.Name, Author = book.Author, Price = book.Price, Genres = book.Genres }).OrderBy(q => q.Id).Skip(offset-1).Take(limit).ToList();
        }


        //get Book by Id 
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            return libraryDbContext.Books.Include(book => book.Genres).Where(book => book.Id == id).FirstOrDefault();
        }
    }
}

