using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Classic, Romance, Thriller;
            bookDbContext.Genre.AddRange(
                SF = new Genre()
                {
                    Id = 1,
                    Name = "SF"
                } ,
                Classic = new Genre()
                {
                    Id = 2,
                    Name = "Classic"
                },
                Romance = new Genre()
                {
                    Id = 3,
                    Name = "Romance"
                },
                Thriller = new Genre()
                {
                    Id = 4,
                    Name = "Thriller"
                }
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Id = 1, Name = "miserables", Author = "Jack", Price = 20, Content = "contenu1", Genres = new List<Genre>() { SF } }, 
                new Book() { Id = 2, Name = "Yves", Author = "Paul", Price = 30, Content = "contenu2" , Genres = new List<Genre>() { SF ,Romance } },
                new Book() { Id = 3, Name = "Poete", Author = "Cristine", Price = 70, Content = "contenu3" , Genres = new List<Genre>() { Thriller } },
                new Book() { Id = 4, Name = "Boheme", Author = "Anne", Price = 90, Content = "contenu4" , Genres = new List<Genre>() { Classic } },
                new Book() { Id = 5, Name = "Paradis", Author = "Smith", Price = 50, Content = "contenu5", Genres = new List<Genre>() { Classic, SF } }
            );
          

            bookDbContext.SaveChanges();
        }
    }
}