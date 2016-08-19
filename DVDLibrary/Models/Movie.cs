using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public Director Director { get; set; }
        public Actor Actor { get; set; }
        public string Title { get; set; }
        public DateTime RealseDate { get; set; }
        public string MPAARating { get; set; }`
        public string Studio { get; set; }
    }
}
