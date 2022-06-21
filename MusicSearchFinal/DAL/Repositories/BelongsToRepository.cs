using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Repositories
{
    using Entities;
    using MySql.Data.MySqlClient;
    static class BelongsToRepository
    {
        #region queries
        private const string ALL_BELONGS_TO = "select * from przynależy";
        //private const string ADD_ALBUM = "insert into 'zespoły'('Nazwa', 'Rok') VALUES ";

        #endregion

        public static List<BelongsTo> DownloadAllBelongs()
        {
            List<BelongsTo> bels = new List<BelongsTo>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_BELONGS_TO, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    bels.Add(new BelongsTo(reader));
                connection.Close();
            }
            return bels;
        }
    }
}
