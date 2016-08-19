using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.WeaponsRepo
{
    public interface IWeaponRepo
    {
        List<Weapon> GetAll();

        Weapon Get(int id);

        void Post(Weapon weapon);

        void Update(Weapon weapon);

        void Delete(int id);

        Weapon GetMostRecentWeapon();

        void ChangePostStatus(int id);

        List<Weapon> GetAllWeaponsByExhibit(int exhibitId);
    }
}
