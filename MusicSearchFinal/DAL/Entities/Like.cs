using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Entities
{
    class Like
    {
        public sbyte IDLikes { get; set; }
        public sbyte IDUser { get; set; }
        public string Name { get; set; }

        public Like(MySqlDataReader reader)
        {
            IDLikes = sbyte.Parse(reader["ID_Ulubienia"].ToString());
            IDUser = sbyte.Parse(reader["ID_Użytkownika"].ToString());
            Name = reader["Nazwa"].ToString();
        }
    }
}
