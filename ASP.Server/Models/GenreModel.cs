using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Models
{
    public class GenreModel
    {
        [Required]
        [Display(Name = "Id")]
        public Int32 Id { get; set; }


        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
        
       

        // Liste des genres séléctionné par l'utilisateur
        public List<int> Books { get; set; }

        public String Picture { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Book> AllBooks { get; init; }
    }

}
