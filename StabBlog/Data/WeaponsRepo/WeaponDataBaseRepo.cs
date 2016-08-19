using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data.DapperRepo;
using Models;

namespace Data.WeaponsRepo
{
    public class WeaponDataBaseRepo : IWeaponRepo
    {

        public List<Weapon> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                string query = @"select w.WeaponId, w.ComingSoon, w.Content, w.DateCreated, w.DateLastModified, w.DatePosted, w.ExhibitId, w.ImagePath, w.PostStatus, w.Title, a.Id, a.FirstName, a.LastName
                                 from Weapons w
	                                inner join AspNetUsers a
		                                on w.UserId = a.Id";
                var weapons = conn.Query<Weapon, Author, Weapon>(query, (wep, ath) => { wep.PostAuthor = ath; return wep; });
                return weapons.ToList();
            }
        }

        public Weapon Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                string query = @"select w.WeaponId, w.ComingSoon, w.Content, w.DateCreated, w.DateLastModified, w.DatePosted, w.ExhibitId, w.ImagePath, w.PostStatus, w.Title, a.Id, a.FirstName, a.LastName
                                 from Weapons w
	                                inner join AspNetUsers a
		                                on w.UserId = a.Id
                                 where w.WeaponId = @id";
                var weapon = conn.Query<Weapon, Author, Weapon>(query, (wep, ath) => { wep.PostAuthor = ath; return wep; }, new {id});
                return weapon.FirstOrDefault();
            }
        }

        public void Post(Weapon weapon)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                weapon.WeaponId =
                    conn.Query<int>(@"insert into weapons(ExhibitId, UserId, Title, Content, DateCreated,  PostStatus, ComingSoon, ImagePath) 
                                values(@ExhibitId, @AuthorId, @Title, @Content, @DateCreated, 
                                     @PostStatus, @ComingSoon, @ImagePath) select cast(scope_identity() as int) ",
                        new
                        {
                            weapon.ExhibitId,
                            weapon.PostAuthor.AuthorId,
                            weapon.Title,
                            weapon.Content,
                            weapon.DateCreated,
                            weapon.PostStatus,
                            weapon.ComingSoon,
                            weapon.ImagePath,
                        }).First();
            }
        }

        public void Update(Weapon weapon)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                conn.Query<Weapon>(
                    @"update weapons set ExhibitId = @ExhibitId, Title = @Title, Content = @Content,
                                    DateLastModified = @DateLastModified, ComingSoon = @ComingSoon, ImagePath = @ImagePath where weaponid =@weaponid", new
                    {
                        weapon.ExhibitId,
                        weapon.Title,
                        weapon.Content,
                        weapon.DateLastModified,
                        weapon.ComingSoon,
                        weapon.ImagePath,
                        weapon.WeaponId
                    });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                conn.Query(@"delete from weapons  where weaponid = @id", new {id});
            }
        }

        public Weapon GetMostRecentWeapon()
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                string query =
                    @"select w.WeaponId, w.Title, w.ImagePath, w.ExhibitId, w.Content, w.ComingSoon, a.Id, a.FirstName, a.LastName
                      from Weapons w
	                    inner join AspNetUsers a
		                    on w.UserId = a.Id 
                      where PostStatus = 1 and ComingSoon = 1
                      order by DatePosted desc";
                var weapon = conn.Query<Weapon, Author, Weapon>(query, (wep, ath) => { wep.PostAuthor = ath; return wep; });
                return weapon.FirstOrDefault();
            }
        }

        public void ChangePostStatus(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                var weapon = Get(id);
                if (weapon.PostStatus == false)
                {
                    conn.Query(@"
                                UPDATE Weapons
                                SET PostStatus = 1,
                                DatePosted = GETDATE()
                                WHERE WeaponId = @id
                                ", new {id});
                }
                else
                {
                    conn.Query(@"
                            UPDATE Weapons
                            SET PostStatus = 0,
                            DatePosted = null
                            WHERE WeaponId = @id
                            ", new { id });
                }
            }
        }

        public List<Weapon> GetAllWeaponsByExhibit(int exhibitId)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                string query =
                    @"select w.WeaponId, w.ComingSoon, w.Content, w.DateCreated, w.DateLastModified, w.DatePosted, w.ExhibitId, w.ImagePath, w.PostStatus, w.Title, a.Id, a.FirstName, a.LastName
                                            from Weapons w
	                                            inner join AspNetUsers a
		                                            on w.UserId = a.Id
                                            where w.ExhibitId = @exhibitId";

                var weapons = conn.Query<Weapon, Author, Weapon>(query, (wep, ath) => { wep.PostAuthor = ath; return wep; }, new { exhibitId });
                return weapons.ToList();
            }
        }
    }
}
