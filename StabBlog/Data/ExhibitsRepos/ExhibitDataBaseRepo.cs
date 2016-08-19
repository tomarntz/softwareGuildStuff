using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data.DapperRepo;
using Models;

namespace Data.ExhibitsRepos
{
    public class ExhibitDataBaseRepo: IExhibitRepo
    {
        public List<Exhibit> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                string query =
                    @"select e.ExhibitId, e.Content, e.DateCreated, e.DateLastModified, e.DatePosted, e.ImagePath, e.PostStatus, e.Title, a.Id, a.FirstName, a.LastName
                                             from Exhibits e
                                                inner join AspNetUsers a
                                                    on e.UserId = a.Id";
                var exhibits = conn.Query<Exhibit, Author, Exhibit>(query, (exb, ath) => { exb.PostAuthor = ath; return exb; });
                return exhibits.ToList();
            }
        }
        
        public Exhibit Get(int exhibitId)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                string query =
                    @"select e.ExhibitId, e.Content, e.DateCreated, e.DateLastModified, e.DatePosted, e.ImagePath, e.PostStatus, e.Title, a.Id, a.FirstName, a.LastName
                      from Exhibits e
                        inner join AspNetUsers a
                            on e.UserId = a.Id
                      where e.ExhibitId = @exhibitId";
                var exhibit = conn.Query<Exhibit, Author, Exhibit>(query, (exb, ath) => { exb.PostAuthor = ath; return exb; }, new {exhibitId});
                return exhibit.FirstOrDefault();
            }
        }

        public void Post(Exhibit exhibitToAdd)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                exhibitToAdd.ExhibitId = conn.Query<int>(@"insert into exhibits(Title, UserId, Content, DateCreated, DatePosted, DateLastModified, PostStatus, ImagePath)
                values(@Title, @AuthorId, @Content, @DateCreated, @DatePosted, @DateLastModified,@PostStatus, @ImagePath) select cast(scope_identity() as int)", new
                {
                    exhibitToAdd.Title,
                    exhibitToAdd.PostAuthor.AuthorId,
                    exhibitToAdd.Content,
                    exhibitToAdd.DateCreated,
                    exhibitToAdd.DateLastModified,
                    exhibitToAdd.DatePosted,
                    exhibitToAdd.PostStatus,
                    exhibitToAdd.ImagePath
                }).First();
            }
           
        }

        public void Update(Exhibit exhibitToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                conn.Query<Exhibit>(@"update exhibits set Title = @Title,  Content = @Content, DateLastModified = @DateLastModified, ImagePath = @ImagePath
                where exhibitId= @ExhibitId", new
                {
                    exhibitToUpdate.Title,
                    exhibitToUpdate.Content,
                    exhibitToUpdate.DateLastModified,
                    exhibitToUpdate.ImagePath,
                    exhibitToUpdate.ExhibitId
                });
            }
        }

        public void Delete(int exhibitId)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                conn.Query(@"
                            DELETE
                            FROM Weapons
                            WHERE ExhibitId = @exhibitId
                            DELETE 
                            FROM Exhibits
                            WHERE ExhibitId = @exhibitId
                            ", new {exhibitId});
            }
        }

        public Exhibit GetMostRecentExhibit()
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                string query =
                    @"select e.ExhibitId, e.Title, e.ImagePath, e.ExhibitId, e.Content, a.Id, a.FirstName, a.LastName
                      from Exhibits e
	                    inner join AspNetUsers a
		                    on e.UserId = a.Id 
                      where PostStatus = 1
                      order by DatePosted desc";
                var exhibit = conn.Query<Exhibit, Author, Exhibit>(query, (exb, ath) => { exb.PostAuthor = ath; return exb; });
                return exhibit.FirstOrDefault();
            }
        }

        public void ChangePostStatus(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                Exhibit exhibitToUpdate = Get(id);
                if (!exhibitToUpdate.PostStatus)
                {
                    conn.Query(@"update Exhibits set PostStatus = 1,  DatePosted = GETDATE() where ExhibitId = @id", new {id});
                }
                else
                {
                    conn.Query(@"update Exhibits set PostStatus = 0,  DatePosted = null where ExhibitId = @id", new { id });
                }
            }
        }
    }
}
