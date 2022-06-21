using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Entities
{
    class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string YearOfOrigin { get; set; }


        public Album(sbyte iD, string name, string yearOfOrigin)
        {
            ID = iD;
            Name = name;
            YearOfOrigin = yearOfOrigin;
        }

        public Album(MySqlDataReader reader)
        {
            ID = int.Parse(reader["ID_Albumu"].ToString());
            Name = reader["Nazwa"].ToString();
            YearOfOrigin = reader["Rok"].ToString();

        }

        public Album(Album album)
        {
            ID = album.ID;
            Name = album.Name;
            YearOfOrigin = album.YearOfOrigin;
        }


        public override string ToString()
        {
            return $"Alb. name: {Name}  Year: {YearOfOrigin}";
        }

        public string ToInsert()
        {
            return $"('{Name}', '{YearOfOrigin}')";
        }

        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var album = obj as Album;
            if (album is null) return false;
            if (Name.ToLower() != album.Name.ToLower()) return false;
            if (YearOfOrigin != album.YearOfOrigin) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
