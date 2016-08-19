using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Data;
using Data.BlogRepo;
using Models;

namespace Tests
{
    [TestFixture]
    public class BlogInMemoryRepoTests
    {
        [Test]
        public void GetAllBlogPostsTest()
        {
            var repo = BlogFactoryRepo.CreateBlogRepo();
            List<Blog> NumberOfPosts = repo.GetAll();

            Assert.AreEqual(NumberOfPosts.Count, 3);
        }

        [Test]
        public void GetBlogPostTest()
        {
            var repo = BlogFactoryRepo.CreateBlogRepo();
            Blog ChoosenBlog = repo.Get(3);

            Assert.AreEqual(ChoosenBlog.Title, "Cats in Historical Weaponry");
        }

        [Test]
        public void DeleteBlogPostTest()
        {
            var repo = BlogFactoryRepo.CreateBlogRepo();
            Blog ChoosenBlog = repo.Get(3);
            repo.Delete(ChoosenBlog.BlogId);
            List<Blog> result = repo.GetAll();

            int expected = 2;

            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void PostBlogTest()
        {
            var repo = BlogFactoryRepo.CreateBlogRepo();
            repo.Post(new Blog());
            List<Blog> NumberOfBlogs = repo.GetAll();

            int expected = 4;

            Assert.AreEqual(expected, NumberOfBlogs.Count);
        }

        [Test]
        public void GetMostRecentBlogTest()
        {
            var repo = BlogFactoryRepo.CreateBlogRepo();
            var result = repo.GetMostRecentBlog();

            var expected = 1;

            Assert.AreEqual(result.BlogId, expected);

        }
    }
}
