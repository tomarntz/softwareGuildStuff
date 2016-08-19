using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Data.CategoriesRepos;
using Data.TagsRepos;
using Models;

namespace Data.BlogRepo
{
    public class BlogInMemoryRepo : IBlogRepo
    {
        private static readonly List<Blog> _blogs;
        private static ICategoryRepo _categoryRepo = CategoryRepoFactory.CreateCategoryRepo();
        private static ITagRepo _tagRepo = TagsRepoFactory.CreateTagRepo();

        static BlogInMemoryRepo() 
        {
            #region Blogs
            if (_blogs == null)
            {
                _blogs = new List<Blog>
                {
                    new Blog
                    {
                        BlogId = 1,
                        PostAuthor = new Author()
                        {
                            FirstName = "Ben",
                            LastName = "Dover"
                        },
                        Categories = new List<Category>
                        {
                            _categoryRepo.GetCategoryById(1),
                            _categoryRepo.GetCategoryById(2)
                        },
                        Tags = new List<Tag>
                        {
                            _tagRepo.GetById(1),
                            _tagRepo.GetById(2),
                            _tagRepo.GetById(4)
                        },
                        Title = "Swords Hurt",
                        Content = "Cable Barbary Coast Jack Ketch draft hempen halter Pirate Round scuppers nipperkin gunwalls run a rig. \n Killick jolly boat boatswain gibbet quarterdeck marooned Jack Ketch crow's nest bilged on her anchor rope's end. Clipper chase guns sloop \n\n cackle fruit list spike landlubber or just lubber aft yard Jack Tar\nSkysail rutters Sink me gaff main sheet crows nest smartly belay cackle fruit boat. Keel spyglass \nscuttle Jolly Roger pillage hornswaggle hands warp galleon cable. Bilge haul wind chantey fire ship red ensign Cat onine tails lanyard avast nipperkin aye.Broadside  boat hail-shot cog \nswing the lead piracy mizzen quarterdeck me loot. Splice the main brace topgallant keel chase league aye yawl Pieces of Eight grog \n\ndeadlights. Pillage run a shot across the bow wench reef sails jury mast hearties pressgang league list American Main.",
                        DateCreated = DateTime.Now.AddDays(-2),
                        DatePosted = DateTime.Today,
                        DateLastModified = DateTime.Today,
                        PostStatus = true,
                        ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwLNJm196WERXdDucOJ2MGNb_MQuH_2jGpCmsHWt1DE8Ihe3Ic"
                        
                        
                    },
                    new Blog
                    {
                        BlogId = 2,
                        PostAuthor = new Author()
                        {
                            FirstName = "Richard",
                            LastName = "Head"
                        },
                        Categories = new List<Category>
                        {
                            _categoryRepo.GetCategoryById(3),
                            _categoryRepo.GetCategoryById(4)
                        },
                        Tags = new List<Tag>
                        {
                            _tagRepo.GetById(3),
                            _tagRepo.GetById(7),
                            _tagRepo.GetById(4)
                        },
                        Title = "Clubs",
                        Content = "Knave chase guns lugsail mizzen rum hang the jib hardtack run a shot across\n the bow Arr strike colors. Haul wind salmagundi broadside Pieces of Eight port to go on account cable coxswain\n\n bounty weigh anchor. Ye scuttle Davy Jones' Locker Sink me hornswaggle gibbet Barbary Coast strike colors\n American Main Sail ho. Nipperkin hulk gally code of conduct reef man-of-war lad me jury mast boom. Bucko overhaul schooner scurvy yard lee parley Jack \n\nTar swab bilge rat. Spanish Main American Main starboard plunder Cat o'nine tails coxswain splice the main brace \nfore crimp fire in the hole. Cable crimp grapple snow draft six pounders prow Barbary Coast Arr scurvy. Tack booty jib crimp nipper mutiny landlubber or just lubber hearties\n measured fer yer chains keelhaul. Cable spirits galleon Yellow Jack scallywag brigantine Davy Jones' Locker quarter blow \n\nthe man down squiffy.",
                        DateCreated = DateTime.Now.AddDays(-2),
                        DatePosted = null,
                        DateLastModified = null,
                        PostStatus = false,
                        ImagePath = "http://www.dailystormer.com/wp-content/uploads/2015/03/DSC05808.jpg"

                    },
                    new Blog
                    {
                        BlogId = 3,
                        PostAuthor = new Author()
                        {
                            FirstName = "Ben",
                            LastName = "Dover"
                        },
                        Categories = new List<Category>
                        {
                            _categoryRepo.GetCategoryById(5)
                        },
                        Tags = new List<Tag>
                        {
                            _tagRepo.GetById(5),
                            _tagRepo.GetById(6),
                            _tagRepo.GetById(4)
                        },
                        Title = "Cats in Historical Weaponry",
                        Content = "Crack Jennys tea cup prow knave Letter of Marque yawl hulk topgallant coxswain swab \nlugsail. Take a caulk draft lanyard line tender aft handsomely parley sheet gun. Quarterdeck main sheet rum quarter galleon \n\ncareen Jolly Roger topsail pillage crack Jennys tea cup. Fire ship marooned case shot cackle fruit splice the\n main brace wherry hands pressgang swab hang the jib. Tender knave spyglass piracy fluke marooned tack nipperkin \ngangplank parrel. Furl Shiver me timbers haul wind brigantine bucko barkadeer driver strike colors rope's end yard. Scourge of the seven seas\n wench warp run a rig me poop deck transom Letter of Marque spanker provost. Sheet quarterdeck galleon execution dock chantey \nrigging weigh anchor snow walk the plank belay. Long boat handsomely trysail cog ye nipperkin \nswab Corsair draught scallywag.",
                        DateCreated = DateTime.Now.AddDays(-4),
                        DatePosted = DateTime.Now.AddDays(-3),
                        DateLastModified = DateTime.Today,
                        PostStatus = true,
                        ImagePath = "http://www.primaryhomeworkhelp.co.uk/romans/images/soldiers/sword.jpg"
                    }
                };
            }
#endregion
        }
        public List<Blog> GetAll()
        {
            return _blogs;
        }

        public Blog Get(int id)
        {
            return _blogs.FirstOrDefault(m => m.BlogId == id);
        }

        public List<Blog> GetAllForAndminPage()
        {
            throw new NotImplementedException();
        }

        public Blog GetSingleBlogForAdminPage(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _blogs.RemoveAll(m => m.BlogId == id);
        }

        public Blog GetMostRecentBlog()
        {
            //this might have to get tweaked
            var blog = _blogs;

            var result = (from b in blog
                where b.PostStatus != false
                orderby b.DatePosted
                select b
                ).First();

            return result;
        }   

        public void Update(Blog blog)
        {
            Delete(blog.BlogId);
            _blogs.Add(blog);
        }

        public void Post(Blog blog)
        {
            blog.BlogId = (_blogs.Any()) ? _blogs.Max(m=>m.BlogId) + 1 : 1;
            _blogs.Add(blog);
        }

        public void ChangePostStatus(int id)
        {
            var blog = Get(id);
            if (blog.PostStatus == false)
            {
                blog.PostStatus = true;
            }
            else
            {
                blog.PostStatus = false;
            }
        }

        public List<Blog> GetByTag(string id)
        {
            var blogsbytag = new List<Blog>();
            foreach (var blog in _blogs)
            {
                foreach (var tag in blog.Tags)
                {
                    if (tag.TagTitle == id)
                    {
                        blogsbytag.Add(blog);
                    }
                }
            }
            return blogsbytag;
        }

        public List<Blog> GetAllBlogsByCategory(int categoryId)
        {
            var blogsByCat = new List<Blog>();
            foreach (var blog in _blogs)
            {
                foreach (var cat in blog.Categories)
                {
                    if (cat.CategoryId == categoryId)
                    {
                        blogsByCat.Add(blog);
                    }
                }
            }
            return blogsByCat;
        }

        public List<Category> CatsByPostStatus()
        {
            var cats = new List<Category>();
            foreach (var blog in _blogs)
            {
                if (blog.PostStatus == true)
                {
                    foreach (var cat in blog.Categories)
                    {
                        cats.Add(cat);
                    }
                }
            }
            return cats;
        }

        public IEnumerable<string> GetTagsByPostStatus()
        {
            var tags = new List<string>();
            foreach (var blog in _blogs)
            {
                if (blog.PostStatus)
                {
                    foreach (var tag in blog.Tags)
                    {
                       tags.Add(tag.TagTitle); 
                    }
                }
            }
            return tags;
        }
    }
}
