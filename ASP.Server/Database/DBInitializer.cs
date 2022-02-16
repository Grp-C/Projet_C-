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
                new Book() { Id = 1, Name = "miserables", Author = "Jack", Price = 20, Content = "In 1798, Napoleon Bonaparte launched an expedition of 35,000 soldiers to conquer Egypt. The campaign was a military and political disaster but nonetheless it had a profound and lasting impact, by revealing the splendour of a mysterious and forgotten civilization. For Napoleon's ships also carried some 500 scholars, scientists and artists whose task it was to study the country and its customs. Traversing a country at war under the stifling heat of southern Egypt, they embarked on the first major study of a land then all but unknown to Europeans. They discovered the Valley of the Kings outside Thebes. They found the Rosetta stone, which when deciphered enabled scholars to read hieroglyphics. And their combined efforts culminated in what is surely one of the most ambitiously comprehensive work ever published: the Description de l'Egypte in 10 volumes with 837 copperplate engravings and more than 3,000 drawings. ", Genres = new List<Genre>() { SF } }, 
                new Book() { Id = 2, Name = "Yves", Author = "Paul", Price = 30, Content = "In 1798, Napoleon Bonaparte launched an expedition of 35,000 soldiers to conquer Egypt. The campaign was a military and political disaster but nonetheless it had a profound and lasting impact, by revealing the splendour of a mysterious and forgotten civilization. For Napoleon's ships also carried some 500 scholars, scientists and artists whose task it was to study the country and its customs. Traversing a country at war under the stifling heat of southern Egypt, they embarked on the first major study of a land then all but unknown to Europeans. They discovered the Valley of the Kings outside Thebes. They found the Rosetta stone, which when deciphered enabled scholars to read hieroglyphics. And their combined efforts culminated in what is surely one of the most ambitiously comprehensive work ever published: the Description de l'Egypte in 10 volumes with 837 copperplate engravings and more than 3,000 drawings.", Genres = new List<Genre>() { SF ,Romance } },
                new Book() { Id = 3, Name = "Poete", Author = "Cristine", Price = 70, Content = "In 1798, Napoleon Bonaparte launched an expedition of 35,000 soldiers to conquer Egypt. The campaign was a military and political disaster but nonetheless it had a profound and lasting impact, by revealing the splendour of a mysterious and forgotten civilization. For Napoleon's ships also carried some 500 scholars, scientists and artists whose task it was to study the country and its customs. Traversing a country at war under the stifling heat of southern Egypt, they embarked on the first major study of a land then all but unknown to Europeans. They discovered the Valley of the Kings outside Thebes. They found the Rosetta stone, which when deciphered enabled scholars to read hieroglyphics. And their combined efforts culminated in what is surely one of the most ambitiously comprehensive work ever published: the Description de l'Egypte in 10 volumes with 837 copperplate engravings and more than 3,000 drawings.", Genres = new List<Genre>() { Thriller } },
                new Book() { Id = 4, Name = "Boheme", Author = "Anne", Price = 90, Content = "In 1798, Napoleon Bonaparte launched an expedition of 35,000 soldiers to conquer Egypt. The campaign was a military and political disaster but nonetheless it had a profound and lasting impact, by revealing the splendour of a mysterious and forgotten civilization. For Napoleon's ships also carried some 500 scholars, scientists and artists whose task it was to study the country and its customs. Traversing a country at war under the stifling heat of southern Egypt, they embarked on the first major study of a land then all but unknown to Europeans. They discovered the Valley of the Kings outside Thebes. They found the Rosetta stone, which when deciphered enabled scholars to read hieroglyphics. And their combined efforts culminated in what is surely one of the most ambitiously comprehensive work ever published: the Description de l'Egypte in 10 volumes with 837 copperplate engravings and more than 3,000 drawings.", Genres = new List<Genre>() { Classic } },
                new Book() { Id = 5, Name = "Paradis", Author = "Smith", Price = 50, Content = "In 1798, Napoleon Bonaparte launched an expedition of 35,000 soldiers to conquer Egypt. The campaign was a military and political disaster but nonetheless it had a profound and lasting impact, by revealing the splendour of a mysterious and forgotten civilization. For Napoleon's ships also carried some 500 scholars, scientists and artists whose task it was to study the country and its customs. Traversing a country at war under the stifling heat of southern Egypt, they embarked on the first major study of a land then all but unknown to Europeans. They discovered the Valley of the Kings outside Thebes. They found the Rosetta stone, which when deciphered enabled scholars to read hieroglyphics. And their combined efforts culminated in what is surely one of the most ambitiously comprehensive work ever published: the Description de l'Egypte in 10 volumes with 837 copperplate engravings and more than 3,000 drawings.", Genres = new List<Genre>() { Classic, SF } }
            );
          

            bookDbContext.SaveChanges();
        }
    }
}