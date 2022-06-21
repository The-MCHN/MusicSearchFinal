using MusicSearchFinal.DAL.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Repositories
{
    class UsersRepository
    {
        #region queries
        private const string ALL_USERS = "select * from użytkownicy";
        private const string ADD_USER = "insert into użytkownicy values \n";
        #endregion

        public static List<Users> DownloadAllUsers()
        {
            List<Users> bands = new List<Users>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_USERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    bands.Add(new Users(reader));
                connection.Close();
            }
            return bands;
        }
        public static bool AddUserToDB(Users user)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_USER} {user.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }

            return stan;
        }
       
    }
}
