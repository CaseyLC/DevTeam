using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class DevTeamRepo
    {
        private readonly DeveloperRepo _developerRepo;
        //FakeDatabase
        protected readonly List<DevTeam> _devTeams = new List<DevTeam>();
        public DevTeamRepo(DeveloperRepo developerRepo)
        {
            _developerRepo = developerRepo;
        }
        //CRUD
        //CREATE
        public bool AddDevTeam(DevTeam newDevTeam)
        {
            int startingCount = _devTeams.Count;
            int uniqueId = GetUniqueId();
            newDevTeam.Id = uniqueId;
            _devTeams.Add(newDevTeam);
            bool wasAdded = (_devTeams.Count > startingCount) ? true : false;
            return wasAdded;
        }
        private int GetUniqueId()
        {
            var count = _devTeams.Count;
            return count += 1;
        }
        //READ
        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }
        public List<DevTeam> GetDevTeamsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            var devTeam = _devTeams.Where(x => x.Name.ToLower() == name.ToLower()).ToList();
            return devTeam;
        }
        public DevTeam GetDevTeamById(int id)
        {
            var devTeam = _devTeams.FirstOrDefault(x => x.Id == id);
            return devTeam;
        }
        public bool UpdateDevTeam(string name, DevTeam devTeam)
        {
            DevTeam foundDevTeam = GetDevTeamById(devTeam.Id);
            if (devTeam != null && foundDevTeam != null)
            {
                foundDevTeam.Name = name;
                return true;
            }
            else
            {
                return false;
            }
        }
        //DELETE
        public bool DeleteDevTeam(int devTeamId)
        {
            if (devTeamId <= 0)
                return false;
            var foundDevTeam = _devTeams.FirstOrDefault(x => x.Id == devTeamId);
            if (foundDevTeam == null)
                return false;
            return _devTeams.Remove(foundDevTeam);
        }
        public bool AddDevToTeam(int developerId, int devTeamId)
        {
            if (developerId <= 0 || devTeamId <= 0)
                return false;
            var foundDevTeam = _devTeams.FirstOrDefault(x => x.Id == devTeamId);
            var foundDeveloper = _developerRepo.GetDevelopers().FirstOrDefault(x => x.Id == developerId);
            if (foundDeveloper == null || foundDevTeam == null)
                return false;
            foundDevTeam.Developers.Add(foundDeveloper);
            return true;
        }
        public List<Developer> GetDevelopersOnTeamById(int devTeamId)
        {
            if (devTeamId <= 0)
                return null;
            var foundDevTeam = _devTeams.FirstOrDefault(x => x.Id == devTeamId);
            if (foundDevTeam == null)
                return null;
            var developers = foundDevTeam.Developers;
            return developers;
        }
    }
}