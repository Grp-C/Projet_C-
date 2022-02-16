using System.Collections.Generic;

namespace ASP.Server.Model
{
    public class BookWrapper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
