using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Entities
{
    class BelongsTo
    {
        public int IDBelongsTo { get; set; }
        public int IDSong { get; set; }
        public int IDAlbum { get; set; }
        public string Name { get; set; }

        public BelongsTo(int iDBelongsTo, int iDSong, int iDAlbum, string name)
        {
            IDBelongsTo = iDBelongsTo;
            IDSong = iDSong;
            IDAlbum = iDAlbum;
            Name = name;
        }

        public BelongsTo(MySqlDataReader reader)
        {
            IDBelongsTo = int.Parse(reader["ID_Przynależności"].ToString());
            IDSong = int.Parse(reader["ID_Piosenki"].ToString());
            IDAlbum = int.Parse(reader["ID_Albumu"].ToString());
            Name = reader["Nazwa"].ToString();
        }
    }
}
