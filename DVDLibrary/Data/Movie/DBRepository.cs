using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class DBRepository : IMovieRepository
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;

        public List<Movie> GetAll()
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Movie";
                cn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie newMovie = new Movie()
                        {
                            MovieId = (int)dr["MovieId"],
                            Title = dr["Title"].ToString(),
                            RealseDate = DateTime.Parse(dr["RealseDate"].ToString()),
                            MPAARating = dr["MPAARating"].ToString(),
                            Studio = dr["Studio"].ToString()
                        };
                        movies.Add(newMovie);
                    }
                }
            }
            return movies;
        }

        public void Add(Movie newMovie)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO Movie(Title,RealseDate,MPAARating,Studio)
                                    VALUES('@Title','@RealseDate','@MPAARating','@Studio')";
                cmd.Parameters.AddWithValue("@Title", newMovie.Title);
                cmd.Parameters.AddWithValue("@RealseDate", newMovie.RealseDate);
                cmd.Parameters.AddWithValue("@MPAARating", newMovie.MPAARating);
                cmd.Parameters.AddWithValue("@Studio", newMovie.Studio);

                cn.Open();

                newMovie.MovieId = (int) cmd.ExecuteScalar();

                SqlCommand cmdDirector = new SqlCommand();
                cmdDirector.Connection = cn;
                cmdDirector.CommandText = @"INSERT INTO Director(MovieId,DirectorName)
                                            VALUES('@MovieId','@DirectorName')";
                cmdDirector.Parameters.AddWithValue("@MovieId", newMovie.MovieId);
                cmdDirector.Parameters.AddWithValue("@DirectorName", newMovie.Director.DirectorName);

                SqlCommand cmdActor = new SqlCommand();
                cmdActor.Connection = cn;
                cmdActor.CommandText = @"INSERT INTO ACTOR(MovieId,ActorName,CharacterRole)
                                         VALUES('@MovieId','@ActorName','@CharacterRole')";
                cmdActor.Parameters.AddWithValue("@MovieId", newMovie.MovieId);
                cmdActor.Parameters.AddWithValue("@ActorName", newMovie.Actor.ActorName);
                cmdActor.Parameters.AddWithValue("@CharacterRole", newMovie.Actor.CharacterRole);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Movie WHERE MovieID = @MovieId";
                cmd.Parameters.AddWithValue("@MovieId", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            Movie movie = new Movie();
            using (SqlConnection cn = new SqlConnection(ConnectionString) )
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Movie WHERE MovieId = @MovieId";
                cmd.Parameters.AddWithValue("@MovieId", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        movie.MovieId = (int) dr["MovieId"];
                        movie.Title = dr["Title"].ToString();
                        movie.RealseDate = DateTime.Parse(dr["RealseDate"].ToString());
                        movie.MPAARating = dr["MPAARating"].ToString();
                        movie.Studio = dr["Studio"].ToString();
                    }
                }
            }
            return movie;
        }
    }
}
