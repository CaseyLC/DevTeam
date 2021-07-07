using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Developer()
        {
        }
        public Developer(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
