using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class User
    {
        public long id { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string country { get; set; }

        public User(){ }

        public User(long id, string name, string surname, string country)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.country = country;
        }
    }
}