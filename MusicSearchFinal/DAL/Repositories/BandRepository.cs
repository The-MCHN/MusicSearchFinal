using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Repositories
{
    using Entities;
    using MySql.Data.MySqlClient;

    static class BandsRepository
    {
        #region queries
        private const string ALL_BANDS = "select * from zespoły";
        private const string ADD_BAND = "insert into zespoły VALUES \n";
        private const string DEL_BAND = "delete from zespoły where Nazwa=";
        #endregion

        public static List<Band> DownloadAllBands()
        {
            List<Band> bands = new List<Band>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_BANDS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    bands.Add(new Band(reader));
                connection.Close();
            }
            return bands;
        }
        public static bool AddBandToDB(Band band)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_BAND} {band.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }

            return stan;
        }

        public static bool DeleteFromDB(Band band)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DEL_BAND}'{band.Name}'", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }

            return stan;
        }
    }
}
