using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Models;
using ASP.Server.Model;

namespace ASP.Server.Controllers
{
    public class GenreController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }


        public ActionResult<IEnumerable<Genre>> List()
        {
            // récupérer les genres dans la base de donées pour qu'elle puisse être affiché
            
            List<Genre> ListGenres = libraryDbContext.Genre.ToList(); ;
            return View(ListGenres);
        }
        public ActionResult<GenreModel> CreateGenre(GenreModel genre)
        {
            // Le IsValid est True uniquement si tous les champs de CreateGenreModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                libraryDbContext.Genre.Add(new Genre() { Id = genre.Id, Name =genre.Name, Picture = genre.Picture }) ;

                // Les information nécéssaire que vous aurez ajoutez

                libraryDbContext.SaveChanges();
                return RedirectToAction("List");
            }

            else 
            {
                return View(new GenreModel());
            }
           
        }


    }
}
