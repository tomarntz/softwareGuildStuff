using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Weapon:IPost
    {
        public int WeaponId { get; set; }
        public int ExhibitId { get; set; }
        public Author PostAuthor { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? DateLastModified { get; set; }
        public bool PostStatus { get; set; }
        public bool ComingSoon { get; set; }
        public string ImagePath { get; set; }

    }
}
