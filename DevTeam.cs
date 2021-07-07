using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class DevTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Developer> Developers { get; set; }
        public DevTeam()
        {
        }
        public DevTeam(int id, string name)
        {
            Id = id;
            Name = name;
            Developers = new List<Developer>();
        }
        public DevTeam(int id, string name, List<Developer> developers)
        {
            Id = id;
            Name = name;
            Developers = developers;
        }
    }
}
