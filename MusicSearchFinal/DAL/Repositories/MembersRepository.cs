using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Repositories
{
    using Entities;
    using MySql.Data.MySqlClient;

    static class MembersRepository
    {
        #region queries
        private const string ALL_MEMBERS = "select * from członkowie";
        private const string ADD_MEMBER = "insert into 'członkowie'('Imię', 'Nazwisko', 'Instrument') VALUES ";

        #endregion

        public static List<Members> DownloadAllMembers()
        {
            List<Members> members = new List<Members>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_MEMBERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    members.Add(new Members(reader));
                connection.Close();
            }
            return members;
        }
        public static bool AddMemberToDB(Members member)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_MEMBER} {member.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }

            return stan;
        }
    }
}
