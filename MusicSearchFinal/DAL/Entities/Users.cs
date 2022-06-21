using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MusicSearchFinal.DAL.Entities
{
    class Users
    {

        public sbyte ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Users(sbyte iD, string name, string surname)
        {
            ID = iD;
            Name = name;
            Surname = surname;
        }

        public Users(MySqlDataReader reader)
        {
            ID = sbyte.Parse(reader["ID_Użytkownika"].ToString());
            Name = reader["Imię"].ToString().Trim();
            Surname = reader["Nazwisko"].ToString().Trim();

        }

        public string ToInsert()
        {
            return $"('{ID}', '{Name}', '{Surname}')";
        }
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var user = obj as Users;
            if (user is null) return false;
            if (Name.ToLower() != user.Name.ToLower()) return false;
            if (Surname.ToLower() != user.Surname.ToLower()) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
