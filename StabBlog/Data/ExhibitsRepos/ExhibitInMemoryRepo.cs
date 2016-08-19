using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.WeaponsRepo;
using Models;

namespace Data.ExhibitsRepos
{

    public class ExhibitInMemoryRepo: IExhibitRepo
    {
        private static readonly List<Exhibit> _Exhibits;
        private static IWeaponRepo _weapon = WeaponFactoryRepo.CreateRepo();

        static ExhibitInMemoryRepo()
        {       
            #region  exhibits
            var repo = WeaponFactoryRepo.CreateRepo();

            if (_Exhibits == null)


            {
                _Exhibits = new List<Exhibit>
                {
                    new Exhibit
                    {
                        ExhibitId = 1,
                        PostAuthor = new Author()
                        {
                            FirstName = "Ben",
                            LastName = "Dover"
                        },
                        
                        Weapons = new List<Weapon>()
                        {
                            _weapon.Get(1),
                        },

                        
                        Title = "Exhibit 1",

                        Content = "Doc, you don't just walk into a store and ask for plutonium. Did you rip this off? I've gotta go. No, fine, no , good, fine, good. Hello, Jennifer. Biff.Hey, Doc? Doc. Hello, anybody home? Einstein, come here, boy. What's going on? Wha- aw, god. Aw, Jesus. Whoa, rock and roll. Yo Precisely. Our first television set, Dad just picked it up today. Do you have a television? Flux capacitor. Oh. I said the \nkeys are in here. Doc, look, all we need is a little plutonium. Never? Marty, I always wear a suit to the office. You alright? Oh, no no no,\n I never uh, I never let anybody read my stories. Something wrong with the starter, so I hid it. Hey not too early I sleep in Sunday's, hey McFly, you're shoe's untied, don't be so\n gullible, McFly. Don't worry. As long as you hit that wire with the connecting hook at precisely 88 miles per hour, the instance the lightning strikes the tower, everything will be fine. No no no, Doc, I just got here, okay, Jennifer's here, we're gonna take the new truck for a spin. Get out of town, I didn'\nt know you did anything creative. Ah, let me read some.1955 You're my ma- you're my ma. Now Biff, don't con me. Working. Shut your filthy mouth, I'm not that kind of girl. Quiet.",

                        DateCreated = DateTime.Parse("8/1/2016"),
                        DatePosted = DateTime.Parse("8/10/2016"),
                        DateLastModified = DateTime.Parse("8/2/2016"),
                        PostStatus = true,
                        ImagePath = "https://upload.wikimedia.org/wikipedia/commons/f/f3/Nicolas_Cage_-_66%C3%A8me_Festival_de_Venise_(Mostra).jpg"

                    },

                    new Exhibit
                    {
                        ExhibitId = 2,
                        PostAuthor = new Author()
                        {
                            FirstName = "Richard",
                            LastName = "Head"
                        },
                        Weapons = new List<Weapon>()
                        {
                            _weapon.Get(1),
                            _weapon.Get(2),
                        },
                        Title = "Exhibit 2",
                        Content = "Yeah. I don't wanna know your name. I don't wanna know anything anything about you. Hey, McFly,\n I thought I told you never to come in here. Well it's gonna cost you. How much money you got on you? Something \n\nthat really cooks. Alright, alright this is an oldie, but uh, it's an oldie where I come from. Alright guys, let's\n do some blues riff in b, watch me for the changes, and uh, try and keep up, okay. Y'know this time it wasn't \n\nmy fault. The Doc set all of his clocks twenty-five minutes slow.",
                        DateCreated = DateTime.Parse("8/3/2016"),
                        DatePosted = null,
                        DateLastModified = DateTime.Parse("8/4/2016"),
                        PostStatus = false,
                        ImagePath = "https://upload.wikimedia.org/wikipedia/commons/9/9d/John_Malkovich_KVIFF_2.jpg"
                    },

                    new Exhibit
                    {
                        ExhibitId = 3,
                        PostAuthor = new Author()
                        {
                            FirstName = "Richard",
                            LastName = "Head"
                        },
                        Weapons = new List<Weapon>()
                        {
                            _weapon.Get(3),
                        },
                        Title = "Exhibit 3",
                        Content = "Good, there's somebody I'd like you to meet. Lorraine. Leave her alone, you \nbastard. Doc, wait. No, bastards. Dammit, Doc, why did you have to tear up that letter? If only I had more time. Wait a minute, I got\n\n all the time I want I got a time machine, I'll just go back and warn him. 10 minutes oughta do it. Time-circuits on, flux-capacitor fluxing, engine running, alright. No, no no no no, c'mon c'mon. C'mon c'mon, here we go, this time. Please, please, c'mon. No, bastards.",
                        DateCreated = DateTime.Parse("8/7/2016"),
                        DatePosted = DateTime.Parse("8/9/2016"),
                        DateLastModified = DateTime.Parse("8/8/2016"),
                        PostStatus = true,
                        ImagePath = "http://www.aveleyman.com/Gallery/ActorsC/3032-23750.gif"
                    }
                };
            }
#endregion
        }
        public List<Exhibit> GetAll()
        {
            return _Exhibits;
        }

        public Exhibit Get(int id)
        {
            return _Exhibits.FirstOrDefault(m => m.ExhibitId == id);
        }

        public void Post(Exhibit exhibit)
        {
            exhibit.ExhibitId = (_Exhibits.Any()) ? _Exhibits.Max(m => m.ExhibitId) + 1 : 1;
            _Exhibits.Add(exhibit);
        }

        public void Update(Exhibit exhibit)
        {
            Delete(exhibit.ExhibitId);
            _Exhibits.Add(exhibit);
        }

        public void Delete(int id)
        {
            _Exhibits.RemoveAll(m => m.ExhibitId == id);
        }

        public Exhibit GetMostRecentExhibit()
        {
            var exhibit = _Exhibits;

            var result = (from e in exhibit
                          where e.PostStatus != false
                          orderby e.DatePosted
                          select e).First();

            return result;
        }

        public void ChangePostStatus(int id)
        {
            var exhibit = Get(id);
            exhibit.PostStatus = true;
        }
    }
}
