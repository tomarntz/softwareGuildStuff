using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data.DapperRepo;
using Models;

namespace Data.BlogRepo
{
    public class BlogDataBaseRepo : IBlogRepo
    {
        private static string conn = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;

        public List<Blog> GetAll()
        {
            List<Blog> blogs = new List<Blog>();

            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"  
                                SELECT b.BlogId, b.Title,b.UserId,b.Content,b.DateCreated,b.DatePosted,
	                                   b.DateLastModified,b.PostStatus,b.ImagePath,t.TagId,t.TagTitle,
		                               c.CategoryId,c.CategoryName,AspNetUsers.FirstName,AspNetUsers.LastName
                                FROM Blogs b
                                LEFT JOIN Blogs_Tags
	                                ON b.BlogId = Blogs_Tags.BlogId
		                        LEFT outer JOIN Tags t
			                        ON t.TagId = Blogs_Tags.TagId
                                LEFT OUTER JOIN Blog_Categories
	                                ON Blog_Categories.BlogId = b.BlogId
		                        LEFT OUTER JOIN Categories c
			                        ON c.CategoryId = Blog_Categories.CategoryId
                                LEFT OUTER JOIN AspNetUsers
	                                ON AspNetUsers.Id = b.UserId
                                WHERE PostStatus  = 1
                                ORDER BY b.BlogId";
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Blog newBlog = blogs.FirstOrDefault(m => m.BlogId == (int) dr["BlogId"]);
                        if (newBlog == null)
                        {

                            newBlog = new Blog
                            {
                                BlogId = (int) dr["BlogId"],
                                Title = dr["Title"].ToString(),
                                PostAuthor = new Author(),
                                Content = dr["Content"].ToString(),
                                DateCreated = DateTime.Parse(dr["DateCreated"].ToString()),
                                ImagePath = dr["ImagePath"].ToString(),
                                PostStatus = (bool) dr["PostStatus"],
                                Categories = new List<Category>(),
                                Tags = new List<Tag>()
                            };
                            blogs.Add(newBlog);

                        }
                        if (dr["TagId"] != DBNull.Value)
                        {
                            Tag newTag = new Tag
                            {
                                TagId = (int) dr["TagId"],
                                TagTitle = dr["TagTitle"].ToString()
                            };

                            if (newBlog.Tags.Any(a => a.TagId == newTag.TagId) == false)
                            {
                                newBlog.Tags.Add(newTag);
                            }
                        }

                        if (dr["CategoryId"] != DBNull.Value)
                        {
                            Category newCategory = new Category
                            {
                                CategoryId = (int) dr["CategoryId"],
                                CategoryName = dr["CategoryName"].ToString()
                            };

                            if (newBlog.Categories.Any(c => c.CategoryId == newCategory.CategoryId) == false)
                            {
                                newBlog.Categories.Add(newCategory);
                            }
                        }

                        if (dr["DatePosted"] != DBNull.Value)
                        {
                            newBlog.DatePosted = DateTime.Parse(dr["DatePosted"].ToString());
                        }
                        if (dr["DateLastModified"] != DBNull.Value)
                        {
                            newBlog.DateLastModified = DateTime.Parse(dr["DateLastModified"].ToString());
                        }

                        Author newAuthor = new Author
                        {
                            AuthorId = dr["UserId"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString()
                        };
                        newBlog.PostAuthor = newAuthor;
                    }
                }
            }
            return blogs;
        }

        public List<Blog> GetAllForAndminPage()
        {
            List<Blog> blogs = new List<Blog>();

            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"  
                                SELECT b.BlogId, b.Title,b.UserId,b.Content,b.DateCreated,b.DatePosted,
	                                   b.DateLastModified,b.PostStatus,b.ImagePath,t.TagId,t.TagTitle,
		                               c.CategoryId,c.CategoryName,AspNetUsers.FirstName,AspNetUsers.LastName
                                FROM Blogs b
                                LEFT JOIN Blogs_Tags
	                                ON b.BlogId = Blogs_Tags.BlogId
		                        LEFT outer JOIN Tags t
			                        ON t.TagId = Blogs_Tags.TagId
                                LEFT OUTER JOIN Blog_Categories
	                                ON Blog_Categories.BlogId = b.BlogId
		                        LEFT OUTER JOIN Categories c
			                        ON c.CategoryId = Blog_Categories.CategoryId
                                LEFT OUTER JOIN AspNetUsers
	                                ON AspNetUsers.Id = b.UserId
                                ORDER BY b.BlogId";
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Blog newBlog = blogs.FirstOrDefault(m => m.BlogId == (int) dr["BlogId"]);
                        if (newBlog == null)
                        {

                            newBlog = new Blog
                            {
                                BlogId = (int) dr["BlogId"],
                                Title = dr["Title"].ToString(),
                                PostAuthor = new Author(),
                                Content = dr["Content"].ToString(),
                                DateCreated = DateTime.Parse(dr["DateCreated"].ToString()),
                                ImagePath = dr["ImagePath"].ToString(),
                                PostStatus = (bool) dr["PostStatus"],
                                Categories = new List<Category>(),
                                Tags = new List<Tag>()
                            };
                            blogs.Add(newBlog);

                        }
                        if (dr["TagId"] != DBNull.Value)
                        {
                            Tag newTag = new Tag
                            {
                                TagId = (int) dr["TagId"],
                                TagTitle = dr["TagTitle"].ToString()
                            };

                            if (newBlog.Tags.Any(a => a.TagId == newTag.TagId) == false)
                            {
                                newBlog.Tags.Add(newTag);
                            }
                        }

                        if (dr["CategoryId"] != DBNull.Value)
                        {
                            Category newCategory = new Category
                            {
                                CategoryId = (int) dr["CategoryId"],
                                CategoryName = dr["CategoryName"].ToString()
                            };

                            if (newBlog.Categories.Any(c => c.CategoryId == newCategory.CategoryId) == false)
                            {
                                newBlog.Categories.Add(newCategory);
                            }
                        }

                        if (dr["DatePosted"] != DBNull.Value)
                        {
                            newBlog.DatePosted = DateTime.Parse(dr["DatePosted"].ToString());
                        }
                        if (dr["DateLastModified"] != DBNull.Value)
                        {
                            newBlog.DateLastModified = DateTime.Parse(dr["DateLastModified"].ToString());
                        }

                        Author newAuthor = new Author
                        {
                            AuthorId = dr["UserId"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString()
                        };
                        newBlog.PostAuthor = newAuthor;
                    }
                }
            }
            return blogs;
        }

        public Blog GetSingleBlogForAdminPage(int id)
        {
            Blog blog = new Blog();
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"  
                                SELECT b.BlogId, b.Title,b.UserId,b.Content,b.DateCreated,b.DatePosted,
	                                   b.DateLastModified,b.PostStatus,b.ImagePath,t.TagId,t.TagTitle,
		                               c.CategoryId,c.CategoryName,AspNetUsers.FirstName,AspNetUsers.LastName
                                FROM Blogs b
                                LEFT JOIN Blogs_Tags
	                                ON b.BlogId = Blogs_Tags.BlogId
		                        LEFT outer JOIN Tags t
			                        ON t.TagId = Blogs_Tags.TagId
                                LEFT OUTER JOIN Blog_Categories
	                                ON Blog_Categories.BlogId = b.BlogId
		                        LEFT OUTER JOIN Categories c
			                        ON c.CategoryId = Blog_Categories.CategoryId
                                LEFT OUTER JOIN AspNetUsers
	                                ON AspNetUsers.Id = b.UserId
                                WHERE b.BlogId  = @Id
                                ";
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        blog.BlogId = (int) dr["BlogId"];
                        blog.Title = dr["Title"].ToString();
                        blog.PostAuthor = new Author();
                        blog.Content = dr["Content"].ToString();
                        blog.Categories = new List<Category>();
                        blog.Tags = new List<Tag>();
                        blog.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        blog.PostStatus = (bool) dr["PostStatus"];
                        blog.ImagePath = dr["ImagePath"].ToString();
                        if (dr["DatePosted"] != DBNull.Value)
                        {
                            blog.DatePosted = DateTime.Parse(dr["DatePosted"].ToString());
                        }
                        if (dr["DateLastModified"] != DBNull.Value)
                        {
                            blog.DateLastModified = DateTime.Parse(dr["DateLastModified"].ToString());
                        }
                        Author newAuthor = new Author
                        {
                            AuthorId = dr["UserId"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString()
                        };
                        blog.PostAuthor = newAuthor;
                        while (dr.Read())
                        {
                            if (dr["TagId"] != DBNull.Value)
                            {
                                Tag newTag = new Tag
                                {
                                    TagId = (int) dr["TagId"],
                                    TagTitle = dr["TagTitle"].ToString()
                                };
                                if (blog.Tags.Any(m => m.TagId == newTag.TagId) == false)
                                {
                                    blog.Tags.Add(newTag);
                                }
                            }

                            if (dr["CategoryId"] != DBNull.Value)
                            {
                                Category newCategory = new Category
                                {
                                    CategoryId = (int) dr["CategoryId"],
                                    CategoryName = dr["CategoryName"].ToString()
                                };

                                if (blog.Categories.Any(c => c.CategoryId == newCategory.CategoryId) == false)
                                {
                                    blog.Categories.Add(newCategory);
                                }
                            }
                        }
                    }
                }
            }
            return blog;
        }

        public Blog Get(int id)
        {
            Blog blog = new Blog();
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"  
                                SELECT b.BlogId, b.Title,b.UserId,b.Content,b.DateCreated,b.DatePosted,
	                                   b.DateLastModified,b.PostStatus,b.ImagePath,t.TagId,t.TagTitle,
		                               c.CategoryId,c.CategoryName,AspNetUsers.FirstName,AspNetUsers.LastName
                                FROM Blogs b
                                LEFT JOIN Blogs_Tags
	                                ON b.BlogId = Blogs_Tags.BlogId
		                        LEFT outer JOIN Tags t
			                        ON t.TagId = Blogs_Tags.TagId
                                LEFT OUTER JOIN Blog_Categories
	                                ON Blog_Categories.BlogId = b.BlogId
		                        LEFT OUTER JOIN Categories c
			                        ON c.CategoryId = Blog_Categories.CategoryId
                                LEFT OUTER JOIN AspNetUsers
	                                ON AspNetUsers.Id = b.UserId
                                WHERE PostStatus  = 1 AND b.BlogId  = @Id
                                ";
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        blog.BlogId = (int) dr["BlogId"];
                        blog.Title = dr["Title"].ToString();
                        blog.PostAuthor = new Author();
                        blog.Content = dr["Content"].ToString();
                        blog.Categories = new List<Category>();
                        blog.Tags = new List<Tag>();
                        blog.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        blog.PostStatus = (bool) dr["PostStatus"];
                        blog.ImagePath = dr["ImagePath"].ToString();
                        if (dr["DatePosted"] != DBNull.Value)
                        {
                            blog.DatePosted = DateTime.Parse(dr["DatePosted"].ToString());
                        }
                        if (dr["DateLastModified"] != DBNull.Value)
                        {
                            blog.DateLastModified = DateTime.Parse(dr["DateLastModified"].ToString());
                        }
                        Author newAuthor = new Author
                        {
                            AuthorId = dr["UserId"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString()
                        };
                        blog.PostAuthor = newAuthor;
                        while (dr.Read())
                        {
                            if (dr["TagId"] != DBNull.Value)
                            {
                                Tag newTag = new Tag
                                {
                                    TagId = (int) dr["TagId"],
                                    TagTitle = dr["TagTitle"].ToString()
                                };
                                if (blog.Tags.Any(m => m.TagId == newTag.TagId) == false)
                                {
                                    blog.Tags.Add(newTag);
                                }
                            }

                            if (dr["CategoryId"] != DBNull.Value)
                            {
                                Category newCategory = new Category
                                {
                                    CategoryId = (int) dr["CategoryId"],
                                    CategoryName = dr["CategoryName"].ToString()
                                };

                                if (blog.Categories.Any(c => c.CategoryId == newCategory.CategoryId) == false)
                                {
                                    blog.Categories.Add(newCategory);
                                }
                            }
                        }
                    }
                }
            }
            return blog;
        }

        public void Post(Blog blog)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                conn.Execute(@"
                            INSERT INTO Blogs
                            (
                                Title,
                                UserId,
                                DateCreated,
                                Content,
                                PostStatus,
                                ImagePath
                            )
                            VALUES
                            (
                                @Title,
                                @AuthorId,
                                @DateCreated,
                                @Content,
                                @PostStatus,
                                @ImagePath
                            ) 
                            select cast(scope_identity() as int)", new
                {
                    blog.Title,
                    blog.PostAuthor.AuthorId,
                    blog.DateCreated,
                    blog.Content,
                    blog.PostStatus,
                    blog.ImagePath,

                });

                blog.BlogId = (int) conn.ExecuteScalar(@"select MAX(BlogId) from Blogs");
                SetBridgeTables(blog);
            }
        }

        public void Update(Blog blog)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                conn.Execute(@"
                            update Blogs
                                set
                                Title = @Title,
                                Content = @Content,
                                DateLastModified = GETDATE(),
                                ImagePath = @ImagePath
                                where BlogId = @BlogId", new
                {
                    blog.Title,
                    blog.Content,
                    blog.ImagePath,
                    blog.BlogId

                });
            }
            DeleteBrideTableConnections(blog.BlogId);
            SetBridgeTables(blog);
        }

        public void DeleteBrideTableConnections(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                conn.Query(@"
                            DELETE
                            FROM Blog_Categories
                            WHERE BlogId = @id
                            DELETE
                            FROM Blogs_Tags
                            WHERE BlogId = @id

                            ", new { id });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                DeleteBrideTableConnections(id);
                conn.Query(@"
                            DELETE 
                            FROM blogs
                            WHERE BlogId = @id
                            ", new {id});
            }
        }

        public Blog GetMostRecentBlog()
        {
            var blogs = GetAll();

            var result = (from b in blogs
                where b.PostStatus == true
                orderby b.DatePosted
                select b).First();

            return result;
        }

        public List<Tag> TagsByBlog(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                return conn.Query<Tag>(@"
                                        SELECT TagTitle
                                        FROM Blogs 
                                            INNER JOIN Blogs_Tags
                                                ON Blogs.BlogId = Blogs_Tags.BlogId
                                            INNER JOIN Tags
                                                ON Blogs_Tags.TagId = Tags.TagId 
                                        WHERE Blogs.BlogId = @id", new {id}).ToList();
            }
        }

        public void ChangePostStatus(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                var blog = GetSingleBlogForAdminPage(id);
                if (blog.PostStatus == false)
                {
                    conn.Query(@"
                                UPDATE Blogs
                                SET PostStatus = 1,
                                DatePosted  = GETDATE()
                                WHERE BlogId = @id", new {DateTime.Now, id});
                }
                else
                {
                    conn.Query(@"
                                UPDATE Blogs
                                SET PostStatus = 0,
                                DatePosted = null
                                WHERE BlogId = @id", new {id});
                }
            }
        }

        public List<Blog> GetByTag(string tagTitle)
        {
            List<Blog> blogs = new List<Blog>();
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"  
                                SELECT b.BlogId, b.Title,b.UserId,b.Content,b.DateCreated,b.DatePosted,
	                                   b.DateLastModified,b.PostStatus,b.ImagePath,t.TagId,t.TagTitle,
		                               c.CategoryId,c.CategoryName,AspNetUsers.FirstName,AspNetUsers.LastName
                                FROM Blogs b
                                LEFT JOIN Blogs_Tags
	                                ON b.BlogId = Blogs_Tags.BlogId
		                        LEFT outer JOIN Tags t
			                        ON t.TagId = Blogs_Tags.TagId
                                LEFT OUTER JOIN Blog_Categories
	                                ON Blog_Categories.BlogId = b.BlogId
		                        LEFT OUTER JOIN Categories c
			                        ON c.CategoryId = Blog_Categories.CategoryId
                                LEFT OUTER JOIN AspNetUsers
	                                ON AspNetUsers.Id = b.UserId
                                WHERE PostStatus  = 1 AND t.TagTitle = @tagTitle
                                ";
                cmd.Parameters.AddWithValue("@tagTitle", tagTitle);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Blog newBlog = blogs.FirstOrDefault(m => m.BlogId == (int) dr["BlogId"]);
                        if (newBlog == null)
                        {

                            newBlog = new Blog
                            {
                                BlogId = (int) dr["BlogId"],
                                Title = dr["Title"].ToString(),
                                PostAuthor = new Author(),
                                Content = dr["Content"].ToString(),
                                DateCreated = DateTime.Parse(dr["DateCreated"].ToString()),
                                ImagePath = dr["ImagePath"].ToString(),
                                PostStatus = (bool) dr["PostStatus"],
                                Categories = new List<Category>(),
                                Tags = new List<Tag>()
                            };
                            blogs.Add(newBlog);

                        }
                        if (dr["TagId"] != DBNull.Value)
                        {
                            Tag newTag = new Tag
                            {
                                TagId = (int) dr["TagId"],
                                TagTitle = dr["TagTitle"].ToString()
                            };

                            if (newBlog.Tags.Any(a => a.TagId == newTag.TagId) == false)
                            {
                                newBlog.Tags.Add(newTag);
                            }
                        }

                        if (dr["CategoryId"] != DBNull.Value)
                        {
                            Category newCategory = new Category
                            {
                                CategoryId = (int) dr["CategoryId"],
                                CategoryName = dr["CategoryName"].ToString()
                            };

                            if (newBlog.Categories.Any(c => c.CategoryId == newCategory.CategoryId) == false)
                            {
                                newBlog.Categories.Add(newCategory);
                            }
                        }

                        if (dr["DatePosted"] != DBNull.Value)
                        {
                            newBlog.DatePosted = DateTime.Parse(dr["DatePosted"].ToString());
                        }
                        if (dr["DateLastModified"] != DBNull.Value)
                        {
                            newBlog.DateLastModified = DateTime.Parse(dr["DateLastModified"].ToString());
                        }

                        Author newAuthor = new Author
                        {
                            AuthorId = dr["UserId"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString()
                        };
                        newBlog.PostAuthor = newAuthor;
                    }
                }
            }
            return blogs;
        }

        public List<Blog> GetAllBlogsByCategory(int categoryId)
        {
            List<Blog> blogs = new List<Blog>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Blog"].ConnectionString)
                )
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"
                                        SELECT b.BlogId, b.Title,b.UserId,b.Content,b.DateCreated,b.DatePosted,
	                                   b.DateLastModified,b.PostStatus,b.ImagePath,t.TagId,t.TagTitle,
		                               c.CategoryId,c.CategoryName,AspNetUsers.FirstName,AspNetUsers.LastName
                                FROM Blogs b
                                LEFT JOIN Blogs_Tags
	                                ON b.BlogId = Blogs_Tags.BlogId
		                        LEFT outer JOIN Tags t
			                        ON t.TagId = Blogs_Tags.TagId
                                LEFT OUTER JOIN Blog_Categories
	                                ON Blog_Categories.BlogId = b.BlogId
		                        LEFT OUTER JOIN Categories c
			                        ON c.CategoryId = Blog_Categories.CategoryId
                                LEFT OUTER JOIN AspNetUsers
	                                ON AspNetUsers.Id = b.UserId
                                WHERE PostStatus  = 1 AND c.CategoryId = @categoryId";
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Blog newBlog = blogs.FirstOrDefault(m => m.BlogId == (int) dr["BlogId"]);
                        if (newBlog == null)
                        {

                            newBlog = new Blog
                            {
                                BlogId = (int) dr["BlogId"],
                                Title = dr["Title"].ToString(),
                                PostAuthor = new Author(),
                                Content = dr["Content"].ToString(),
                                DateCreated = DateTime.Parse(dr["DateCreated"].ToString()),
                                ImagePath = dr["ImagePath"].ToString(),
                                PostStatus = (bool) dr["PostStatus"],
                                Categories = new List<Category>(),
                                Tags = new List<Tag>()
                            };
                            blogs.Add(newBlog);

                        }
                        if (dr["TagId"] != DBNull.Value)
                        {
                            Tag newTag = new Tag
                            {
                                TagId = (int) dr["TagId"],
                                TagTitle = dr["TagTitle"].ToString()
                            };

                            if (newBlog.Tags.Any(a => a.TagId == newTag.TagId) == false)
                            {
                                newBlog.Tags.Add(newTag);
                            }
                        }

                        if (dr["CategoryId"] != DBNull.Value)
                        {
                            Category newCategory = new Category
                            {
                                CategoryId = (int) dr["CategoryId"],
                                CategoryName = dr["CategoryName"].ToString()
                            };

                            if (newBlog.Categories.Any(c => c.CategoryId == newCategory.CategoryId) == false)
                            {
                                newBlog.Categories.Add(newCategory);
                            }
                        }

                        if (dr["DatePosted"] != DBNull.Value)
                        {
                            newBlog.DatePosted = DateTime.Parse(dr["DatePosted"].ToString());
                        }
                        if (dr["DateLastModified"] != DBNull.Value)
                        {
                            newBlog.DateLastModified = DateTime.Parse(dr["DateLastModified"].ToString());
                        }

                        Author newAuthor = new Author
                        {
                            AuthorId = dr["UserId"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString()
                        };
                        newBlog.PostAuthor = newAuthor;
                    }
                }
            }
            return blogs;
        }

        public List<Category> CatsByPostStatus()
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Blog"].ConnectionString)
                )
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Categories.CategoryId, CategoryName
                                            FROM Blogs
                                                INNER JOIN Blog_Categories
                                                    ON Blogs.BlogId = Blog_Categories.BlogId
                                                        INNER JOIN Categories
                                                            ON Blog_Categories.CategoryId = Categories.CategoryId
                                            WHERE PostStatus = 1";
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Category category = categories.FirstOrDefault(m => m.CategoryId == (int) dr["CategoryId"]);
                        if (category == null)
                        {
                            category = new Category
                            {
                                CategoryId = (int) dr["CategoryId"],
                                CategoryName = dr["CategoryName"].ToString()
                            };
                            if (categories.Any(m => m.CategoryId == category.CategoryId) == false)
                            {
                                categories.Add(category);
                            }
                        }

                    }
                }
            }
            return categories;
        }

        public IEnumerable<string> GetTagsByPostStatus()
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                return conn.Query<string>(@"
                                         SELECT TagTitle, Blogs.BlogId
                                        FROM Blogs
	                                        INNER JOIN Blogs_Tags
		                                        ON Blogs.BlogId = Blogs_Tags.BlogId
													INNER JOIN Tags
														ON .Blogs_Tags.TagId = Tags.TagId
                                        WHERE PostStatus = 1").ToList();
            }
        }

        public void SetBridgeTables(Blog post)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                foreach (var cat in post.Categories)
                {
                    conn.Execute(@"insert into Blog_Categories
                                   (
                                    BlogId,
                                    CategoryId
                                    )
                                    values (
                                    @BlogId,
                                    @CategoryId)",
                        new
                        {
                            post.BlogId,
                            cat.CategoryId
                        });
                }

                foreach (var tag in post.Tags)
                {
                    conn.Execute(@"insert into Blogs_Tags
                                   (
                                    BlogId,
                                    TagId
                                    )
                                    values (
                                    @BlogId,
                                    @TagId)", new
                    {
                        @post.BlogId,
                        @tag.TagId
                    });
                }
            }
        }
    }
}
