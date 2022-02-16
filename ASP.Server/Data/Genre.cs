using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Server.Model
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }

         }

}

