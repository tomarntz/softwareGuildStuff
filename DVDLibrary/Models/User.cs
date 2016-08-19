using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string UserName { get; set; }
        public int UserRating { get; set; }
        public string UserNotes { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }
    }
}
