using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Repositories
{
    using Entities;
    using MySql.Data.MySqlClient;

    static class AlbumRepository
    {
        #region queries
        private const string ALL_ALBUMS = "select * from albumy";
        private const string ADD_ALBUM = "insert into 'zespoły'('Nazwa', 'Rok') VALUES ";

        #endregion

        public static List<Album> DownloadAllAlbums() { 
            List<Album> albums = new List<Album>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_ALBUMS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    albums.Add(new Album(reader));
                connection.Close();
            }
            return albums;
        }
        public static bool AddBandToDB(Album album)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_ALBUM} {album.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }

            return stan;
        }
    }
}
