using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Models
{
    public class BookModel
    {
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre

        [Required]
        [Display(Name = "Author")]
        public String Author { get; set; }
        [Required]
        [Display(Name = "Price")]
        public Double Price { get; set; }
        [Required]
        [Display(Name = "Content")]
        public String Content { get; set; }

        // Liste des genres séléctionné par l'utilisateur
        public List<int> Genres { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init; }
    }
}
