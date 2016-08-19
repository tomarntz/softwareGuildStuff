using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.TagsRepos
{
    public interface ITagRepo
    {
        IEnumerable<string> GetAll();

        Tag Post(Tag tagToAdd);

        Tag GetById(int id);
    }
}
