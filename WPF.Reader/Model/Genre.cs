using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Reader.Model
{
    internal class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public List<int> Books { get; set; }
    }
}
