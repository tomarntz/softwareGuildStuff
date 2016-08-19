using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IPost
    {
        string Title { get; set; }
        Author PostAuthor { get; set; }
        string Content { get; set; }
        bool PostStatus { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DatePosted { get; set; }
        DateTime? DateLastModified { get; set; }
    }
}
