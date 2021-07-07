using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class DeveloperRepo
    {
        //FakeDatabase
        protected readonly List<Developer> _developers = new List<Developer>();
        //CRUD
        //CREATE
        public bool AddDeveloper(Developer newDeveloper)
        {
            int startingCount = _developers.Count;
            int uniqueId = GetUniqueId();
            newDeveloper.Id = uniqueId;
            _developers.Add(newDeveloper);
            bool wasAdded = (_developers.Count > startingCount) ? true : false;
            return wasAdded;
        }
        private int GetUniqueId()
        {
            var count = _developers.Count;
            return count += 1;
        }
        //READ
        public List<Developer> GetDevelopers()
        {
            return _developers;
        }
        public Developer GetDeveloperByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            var dev = _developers.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            return dev;
        }
        public Developer GetDeveloperById(int id)
        {
            var dev = _developers.FirstOrDefault(x => x.Id == id);
            return dev;
        }
        //UPDATE
        public bool UpdateDeveloper(string updatedName, Developer developer)
        {
            Developer foundDeveloper = GetDeveloperById(developer.Id);
            if (developer != null && foundDeveloper != null)
            {
                foundDeveloper.Name = updatedName;
                return true;
            }
            else
            {
                return false;
            }
        }
        //DELETE
        public bool DeleteDeveloper(int developerId)
        {
            if (developerId <= 0)
                return false;
            var foundDeveloper = _developers.FirstOrDefault(x => x.Id == developerId);
            if (foundDeveloper == null)
                return false;
            return _developers.Remove(foundDeveloper);
        }
    }
}