using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data.DapperRepo;
using Models;

namespace Data.TagsRepos
{
    public class TagsDataBaseRepo : ITagRepo
    {
        public IEnumerable<string> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                return conn.Query<string>(@"select t.TagTitle
                                            from Tags t");
            }
        }

        public Tag Post(Tag tagToAdd)
        {
            List<Tag> allTags = new List<Tag>();

            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                allTags = conn.Query<Tag>(@"select * from Tags").ToList();
            }

            bool isOld = false;
            foreach (var tag in allTags)
            {
                if (tag.TagTitle == tagToAdd.TagTitle)
                {
                    isOld = true;
                    tagToAdd.TagId = tag.TagId;
                    break;
                }
            }
            if (!isOld)
            {
                using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
                {
                    tagToAdd.TagId = conn.Query<int>(@"insert into Tags(TagTitle)
                    values(@Title) select cast(scope_identity() as int)", new
                    {
                        Title = tagToAdd.TagTitle
                    }).First();
                }
             }
            return tagToAdd;
        }

        public Tag GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                return conn.Query<Tag>(@"select TagTitle
	                                            from Tags
		                                            where TagId = @id", new { id }).FirstOrDefault();
            }
        }
    }
}
