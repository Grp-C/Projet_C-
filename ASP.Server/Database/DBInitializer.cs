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
                    Name = "SF",
                    Picture = "https://www.futuribles.com/media/base/main/SFetScience.jpg.560x300_q85_box-0%2C47%2C1000%2C582_crop_detail.jpg"
                } ,
                Classic = new Genre()
                {
                    Id = 2,
                    Name = "Classic",
                    Picture = "https://cdn.radiofrance.fr/s3/cruiser-production/2021/02/23ccba05-9bc7-48e1-8718-d720e6d470f3/1136_jean-beraud-belle-epoque-paris.webp"
                },
                Romance = new Genre()
                {
                    Id = 3,
                    Name = "Romance",
                    Picture = "https://www.silverpetticoatreview.com/wp-content/uploads/2017/07/The-Lake-House-Featured-Image.jpg"
                },
                Thriller = new Genre()
                {
                    Id = 4,
                    Name = "Thriller",
                    Picture = "https://d1yjjnpx0p53s8.cloudfront.net/styles/logo-original-577x577/s3/112012/thriller.png?itok=sfbL50uU"
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