using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Repositories
{
    using Entities;
    using MySql.Data.MySqlClient;

    static class SongRepository
    {
        #region queries
        private const string ALL_SONGS = "select * from piosenki";
        private const string ADD_SONG = "insert into 'zespoły'('Nazwa', 'Rok') VALUES ";

        #endregion

        public static List<Song> DownloadAllSongs()
        {
            List<Song> songs = new List<Song>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_SONGS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    songs.Add(new Song(reader));
                connection.Close();
            }
            return songs;
        }
        public static bool AddBandToDB(Song song)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_SONG} {song.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }

            return stan;
        }
    }
}
