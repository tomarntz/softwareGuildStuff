using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.ExhibitsRepos
{
    public interface IExhibitRepo
    {
        List<Exhibit> GetAll();

        Exhibit Get(int id);

        void Post(Exhibit exhibit);

        void Update(Exhibit exhibit);

        void Delete(int id);

        Exhibit GetMostRecentExhibit();

        void ChangePostStatus(int id);
    }
}
