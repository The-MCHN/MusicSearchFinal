using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Entities
{
    class Band
    {

        #region Properties
        public string Name { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public string Concerts { get; set; }
        #endregion

        #region ctrs
        public Band(string name, string country, string genre, string concerts)
        {
            Name = name.Trim();
            Country = country.Trim();
            Genre = genre.Trim();
            Concerts = concerts.Trim();
        }

        public Band(MySqlDataReader reader)
        {
            Name = reader["Nazwa"].ToString();
            Country = reader["Kraj"].ToString();
            Genre = reader["Gatunek"].ToString();
            Concerts = reader["Koncerty"].ToString();
        }

        public Band(Band band)
        {
            Name = band.Name;
            Country = band.Country;
            Genre = band.Genre;
            Concerts = band.Concerts;
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return $"{Name} z {Country}, Gatunek: {Genre} Koncertuje: {Concerts}";
        }

        public string ToInsert()
        {
            return $"('{Name}', '{Country}', '{Genre}', '{Concerts}')";
        }

        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var band = obj as Band;
            if (band is null) return false;
            if (Name.ToLower() != band.Name.ToLower()) return false;
            if (Country.ToLower() != band.Country.ToLower()) return false;
            if (Genre.ToLower() != band.Genre.ToLower()) return false;
            if (Concerts.ToLower() != band.Concerts.ToLower()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
