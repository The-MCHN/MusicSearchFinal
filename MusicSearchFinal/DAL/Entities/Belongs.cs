using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MusicSearchFinal.DAL.Entities
{
    class Belongs
    {

        public int IDofBelonging { get; set; }
        public int IDMember { get; set; }
        public string Name { get; set; }

        public Belongs(sbyte iDofBelonging, sbyte iDMember, string name)
        {
            IDofBelonging = iDofBelonging;
            IDMember = iDMember;
            Name = name;
        }

        public Belongs(Belongs bel)
        {
            IDofBelonging = bel.IDofBelonging;
            IDMember = bel.IDMember;
            Name = bel.Name;
        }

        public Belongs(MySqlDataReader reader)
        {
            IDofBelonging = int.Parse(reader["ID_Należenia"].ToString());
            IDMember = int.Parse(reader["ID_Członka"].ToString());
            Name = reader["Nazwa"].ToString();
        }
       
    }
}
