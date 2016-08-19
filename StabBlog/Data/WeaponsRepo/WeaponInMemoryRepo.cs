using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.WeaponsRepo
{
    public class WeaponInMemoryRepo : IWeaponRepo
    {
        private static readonly List<Weapon> _weapons;

        static WeaponInMemoryRepo()
        {
            #region Weapons
                        if (_weapons == null)
                        {
                            _weapons = new List<Weapon>
                            {
                                new Weapon
                                {
                                    WeaponId = 1,
                                    ExhibitId = 1,
                                    PostAuthor = new Author()
                                    {
                                        FirstName = "Ben",
                                        LastName = "Dover"
                                    },
                                    Title = "Long Sword",
                                    Content = "Main sheet dance the hempen jig knave hogshead heave to brigantine\n man-of-war bilged on her anchor lass black spot. Sail ho league\n\n doubloon Jack Ketch spike yardarm fire ship measured fer yer chains\n grapple crack Jennys tea cup. Hornswaggle gabion Sea Legs fire in the hole Sail ho fore lugsail Pieces of \nEight boom execution dock.",
                                    DateCreated = DateTime.Today.Subtract(TimeSpan.FromDays(2)),
                                    DatePosted = DateTime.Today.Subtract(TimeSpan.FromDays(1)),
                                    PostStatus = true,
                                    ComingSoon = false,
                                    ImagePath = "https://pixabay.com/static/uploads/photo/2012/04/12/10/17/jackknife-29321_960_720.png"
                                },
                                new Weapon
                                {
                                    WeaponId = 2,
                                    ExhibitId = 2,
                                    PostAuthor = new Author()
                                    {
                                        FirstName = "Richard",
                                        LastName = "Head"
                                    },
                                    Title = "Axe",
                                    Content = "Ahoy Blimey mizzenmast parrel deadlights league man-of-war \nspike yawl Jolly Roger. Black spot heave to chandler loot swab coffer cackle fruit swing the lead\n\n draft Sink me. Letter of Marque overhaul reef sails snow prow poop deck fathom clap of thunder loot pinnace.",
                                    DateCreated = DateTime.Today.Subtract(TimeSpan.FromDays(1)),
                                    DatePosted = DateTime.Today,
                                    PostStatus = true,
                                    ComingSoon = true,
                                    ImagePath = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQGJyppZtga49pGUH2n6SNoIsyp3yc6BagUQ244ktmb9gPlTYyWWQ"
                                },
                                new Weapon
                                {
                                    WeaponId = 3,
                                    ExhibitId = 3,
                                    PostAuthor = new Author()
                                    {
                                        FirstName = "Ben",
                                        LastName = "Dover"
                                    },
                                    Title = "Stick",
                                    Content = "JEJEJEJEJEJE Ahoy Blimey mizzenmast parrel deadlights league man-of-war \nspike yawl Jolly Roger. Black spot heave to chandler loot swab coffer cackle fruit swing the lead\n\n draft Sink me. Letter of Marque overhaul reef sails snow prow poop deck fathom clap of thunder loot pinnace.",
                                    DateCreated = DateTime.Today.Subtract(TimeSpan.FromDays(1)),
                                    DatePosted = DateTime.Today,
                                    PostStatus = false,
                                    ComingSoon = true,
                                    ImagePath = "http://cdn.hiconsumption.com/wp-content/uploads/2013/12/Zombie-Hammer-Survival-Weapons-1.jpg"
                                }
                            };
                        }
            #endregion
        }
        public List<Weapon> GetAll()
        {
            return _weapons;
        }

        public Weapon Get(int id)
        {
            return _weapons.FirstOrDefault(m => m.WeaponId == id);
        }

        public void Post(Weapon weapon)
        {
            weapon.WeaponId = (_weapons.Any()) ? _weapons.Max(m => m.WeaponId) + 1 : 1;
            _weapons.Add(weapon);
        }

        public void Update(Weapon weapon)
        {
            Delete(weapon.WeaponId);
            _weapons.Add(weapon);
        }

        public void Delete(int id)
        {
            _weapons.RemoveAll(m => m.WeaponId == id);
        }

        public Weapon GetMostRecentWeapon()
        {
            var weapon = _weapons;

            var result = (from w in weapon
                where w.ComingSoon == true && w.PostStatus == true
                orderby w.DatePosted
                select w).First();

            return result;
        }


        public void ChangePostStatus(int id)
        {
            var weapon = Get(id);
            weapon.PostStatus = true;
        }

        public List<Weapon> GetAllWeaponsByExhibit(int exhibitId)
        {
            List<Weapon> weapons = new List<Weapon>();
            foreach (var weapon in _weapons)
            {
                if (weapon.ExhibitId == exhibitId)
                {
                    weapons.Add(weapon);
                }
            }

            return weapons;
        }

    }
}
