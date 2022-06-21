using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.DAL.Entities
{
    class Members
    {
        public int IDMember { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Instrument { get; set; }



        public Members(MySqlDataReader reader)
        {
            IDMember = int.Parse(reader["ID_Członka"].ToString());
            Name = reader["Imię"].ToString();
            Surname = reader["Nazwisko"].ToString();
            Instrument = reader["Instrument"].ToString();

        }

        public Members(int iDMember, string name, string surname, string instrument)
        {
            IDMember = iDMember;
            Name = name;
            Surname = surname;
            Instrument = instrument;
        }
        public Members(Members mem)
        {
            IDMember = mem.IDMember;
            Name = mem.Name;
            Surname = mem.Surname;
            Instrument = mem.Instrument;
        }

        public string ToInsert()
        {
            return $"('{Name}', '{Surname}', '{Instrument}')";
        }
        public override string ToString()
        {
            return $"Art. name: {Name} {Surname}  Instrument(s): {Instrument}";
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
