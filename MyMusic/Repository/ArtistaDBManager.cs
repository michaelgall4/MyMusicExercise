using MyMusic.Models;
using System.Data.SqlClient;

namespace MyMusic.Repository
{
    public class ArtistaDBManager
    {
        string connectionString = @"Server = ACADEMYNETPD03\SQLEXPRESS; DataBase = MyMusic; Trusted_Connection = true";


        public List<ArtistaViewModel> GetAllArtisti()
        {
            string connectionString = @"Server = ACADEMYNETPD03\SQLEXPRESS; DataBase = MyMusic; Trusted_Connection = true";
            List<ArtistaViewModel> artistaList = new List<ArtistaViewModel>();
            string sql = @"Select * from Artista";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            ArtistaViewModel artista;
            while (reader.Read())
            {
                artista = new ArtistaViewModel()
                {
                    IdArtista = Convert.ToInt32(reader["IdArtista"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    Aka = reader["Aka"].ToString(),
                    Tipo = reader["Tipo"].ToString()
                };
                artistaList.Add(artista);
            }

            return artistaList;
        }

        public int EditArtista(ArtistaViewModel artista)
        {
            string sql = @"UPDATE [dbo].[Artista]
                               SET [Nome] = @Nome
                                  ,[Cognome] = @Cognome
                                  ,[Aka] = @Aka
                                  ,[Tipo] = @Tipo
                             WHERE IdArtista = @idArtista";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", artista.Nome);
            command.Parameters.AddWithValue("@Cognome", artista.Cognome);
            command.Parameters.AddWithValue("@Aka", artista.Aka);
            command.Parameters.AddWithValue("@Tipo", artista.Tipo);
            command.Parameters.AddWithValue("@IdArtista", artista.IdArtista);
            return command.ExecuteNonQuery();
        }

        public int AddArtista(ArtistaViewModel artista)
        {
            string sql = @"INSERT INTO [dbo].[Artista]
                                ([Nome],[Cognome],[Aka],[Tipo])
                                values (@Nome, @Cognome, @Aka, @Tipo)";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", artista.Nome);
            command.Parameters.AddWithValue("@Cognome", artista.Cognome);
            command.Parameters.AddWithValue("@Aka", artista.Aka);
            command.Parameters.AddWithValue("@Tipo", artista.Tipo);
            return command.ExecuteNonQuery();
        }

        public int DetailsArtista(ArtistaViewModel artista)
        {
            string sql = @"SELECT [IdArtista],
                                  [Nome],
                                  [Cognome],
                                  [Aka],
                                  [Tipo]
                              FROM [dbo].[Artista]";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", artista.Nome);
            command.Parameters.AddWithValue("@Cognome", artista.Cognome);
            command.Parameters.AddWithValue("@Aka", artista.Aka);
            command.Parameters.AddWithValue("@Tipo", artista.Tipo);
            command.Parameters.AddWithValue("@IdArtista", artista.IdArtista);
            return command.ExecuteNonQuery();
        }
    }
}
