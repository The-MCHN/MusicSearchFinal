using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Entities
{
    class Song
    {
        public int IDSong { get; set; }
        public string SongName { get; set; }


        public Song(int iDSong, string songName)
        {
            IDSong = iDSong;
            SongName = songName;
        }
        public Song(MySqlDataReader reader)
        {
            IDSong = int.Parse(reader["ID_Piosenki"].ToString());
            SongName = reader["Nazwa"].ToString();

        }

        public Song(Song s)
        {
            IDSong = s.IDSong;
            SongName = s.SongName;
        }

        public string ToInsert()
        {
            return $"'{IDSong}', '{SongName}'";
        }
        public override string ToString()
        {
            return $"Song name: {SongName}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var song = obj as Song;
            if (song is null) return false;
            if (SongName.ToLower() != song.SongName.ToLower()) return false;
            return true;
        }
    }
}
