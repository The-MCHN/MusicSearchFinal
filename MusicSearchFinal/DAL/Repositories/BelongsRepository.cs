using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Repositories
{
    using Entities;
    using MySql.Data.MySqlClient;
    static class BelongsRepository
    {
        #region queries
        private const string ALL_BELONGS = "select * from należy";
        //private const string ADD_ALBUM = "insert into 'zespoły'('Nazwa', 'Rok') VALUES ";

        #endregion

        public static List<Belongs> DownloadAllBelongs()
        {
            List<Belongs> bels = new List<Belongs>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_BELONGS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    bels.Add(new Belongs(reader));
                connection.Close();
            }
            return bels;
        }
    }
}
