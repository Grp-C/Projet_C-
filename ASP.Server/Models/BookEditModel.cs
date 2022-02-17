using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Models
{
    public class BookEditModel
    {
       [Required]
       public BookModel Book { get; set; }

        // Liste des genres séléctionné par l'utilisateur
        public List<Genre> Genres { get; set; }


        
    }
}
