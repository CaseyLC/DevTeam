using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class KomodoUI
    {
        private readonly DeveloperRepo _developerRepo;
        private readonly DevTeamRepo _devTeamRepo;
        public KomodoUI()
        {
            _developerRepo = new DeveloperRepo();
            _devTeamRepo = new DevTeamRepo(_developerRepo);
        }
        //This is the method that runs our User Interface
        public void Run()
        {
            DisplayMenu();
        }
        public void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Pleses select an option!:\n" +
                    "1. Show all Developers\n" +
                    "2. Create a new Developer\n" +
                    "3. Remove a Developer\n" +
                    "4. Update Developers\n" +
                    "5. Show All DevTeams\n" +
                    "6. Create New DevTeam\n" +
                    "7. Remove DevTeam\n" +
                    "8. Update DevTeams\n" +
                    "9. Add a Developer to a Team\n" +
                    "10. Show Developers on a Team\n" +
                    "11. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show all developers
                        ShowAllDevelopers();
                        break;
                    case "2":
                        //Creating a developer
                        CreateNewDeveloper();
                        break;
                    case "3":
                        //removing a developer
                        RemoveDeveloper();
                        break;
                    case "4":
                        //Update a developer's info
                        UpdateDeveloper();
                        break;
                    case "5":
                        //Showing all DevTeams
                        ShowAllDevTeams();
                        break;
                    case "6":
                        //Add new streaming content
                        CreateNewDevTeam();
                        break;
                    case "7":
                        //Remove a DevTeam
                        RemoveDevTeam();
                        break;
                    case "8":
                        //Update a DevTeam's info
                        UpdateDevTeam();
                        break;
                    case "9":
                        AddDevsToTeam();
                        break;
                    case "10":
                        ShowAllDevelopersOnTeam();
                        break;
                    case "11":
                        //Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number bewtween 1 and 9");
                        break;
                }
            }
        }
        private void ShowAllDevelopers()
        {
            Console.Clear();
            List<Developer> developers = _developerRepo.GetDevelopers();
            foreach (Developer developer in developers)
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {developer.Id}");
                Console.WriteLine($"Name: { developer.Name}");
            }
            Console.ReadLine();
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of the new developer: ");
            string name = Console.ReadLine();
            //New up Content at end
            Developer developer = new Developer(0, name);
            //Add to repositroy
            _developerRepo.AddDeveloper(developer);
        }
        private void RemoveDeveloper()
        {
            Console.Clear();
            //Select the content to delete
            //Get Content by title
            Console.WriteLine("Enter the ID of the developer you would like to remove:");
            var id = Convert.ToInt32(Console.ReadLine());
            var isDeleted = _developerRepo.DeleteDeveloper(id);
            if (isDeleted)
                Console.WriteLine("Removal successful");
            else
                Console.WriteLine("Removal failed");
            Console.ReadLine();
        }
        private void ShowAllDevTeams()
        {
            Console.Clear();
            List<DevTeam> developerTeams = _devTeamRepo.GetDevTeams();
            foreach (DevTeam devTeam in developerTeams)
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {devTeam.Id}");
                Console.WriteLine($"Name: { devTeam.Name}");
            }
            Console.ReadLine();
        }
        private void UpdateDeveloper()
        {
            Console.WriteLine("Current Developers:");
            foreach (var developer in _developerRepo.GetDevelopers())
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {developer.Id}");
                Console.WriteLine($"Name: { developer.Name}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Please enter developer Id of the name you would like to change:");
            var id = Convert.ToInt32(Console.ReadLine());
            var foundDeveloper = _developerRepo.GetDeveloperById(id);
            if (foundDeveloper == null)
            {
                Console.WriteLine("Developer not found");
                return;
            }
            Console.WriteLine($"Please enter the new name for Developer ID:{foundDeveloper.Id}");
            var updatedName = Console.ReadLine();
            var isUpdated = _developerRepo.UpdateDeveloper(updatedName, foundDeveloper);
            if (isUpdated)
                Console.WriteLine("Update successful");
            else
                Console.WriteLine("Update failed");
            Console.ReadLine();
        }
        private void CreateNewDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of the new DevTeam: ");
            string name = Console.ReadLine();
            //New up Content at end
            DevTeam devTeam = new DevTeam(0, name);
            //Add to repositroy
            _devTeamRepo.AddDevTeam(devTeam);
        }
        private void RemoveDevTeam()
        {
            Console.Clear();
            //Select the content to delete
            //Get Content by title
            Console.WriteLine("Enter the ID of the DevTeam you would like to remove:");
            var id = Convert.ToInt32(Console.ReadLine());
            var isDeleted = _devTeamRepo.DeleteDevTeam(id);
            if (isDeleted)
                Console.WriteLine("Removal successful");
            else
                Console.WriteLine("Removal failed");
            Console.ReadLine();
        }
        private void UpdateDevTeam()
        {
            Console.WriteLine("Current DevTeams:");
            foreach (var devTeam in _devTeamRepo.GetDevTeams())
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {devTeam.Id}");
                Console.WriteLine($"Name: { devTeam.Name}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Please enter DevTeam Id of the name you would like to change:");
            var id = Convert.ToInt32(Console.ReadLine());
            var foundDevTeam = _devTeamRepo.GetDevTeamById(id);
            if (foundDevTeam == null)
            {
                Console.WriteLine("DevTeam not found");
                return;
            }
            Console.WriteLine($"Please enter the new name for DevTeam ID:{foundDevTeam.Id}");
            var updatedName = Console.ReadLine();
            var isUpdated = _devTeamRepo.UpdateDevTeam(updatedName, foundDevTeam);
            if (isUpdated)
                Console.WriteLine("Update successful");
            else
                Console.WriteLine("Update failed");
            Console.ReadLine();
        }
        public void AddDevsToTeam()
        {
            Console.Clear();
            List<DevTeam> developerTeams = _devTeamRepo.GetDevTeams();
            foreach (DevTeam devTeam in developerTeams)
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {devTeam.Id}");
                Console.WriteLine($"Name: { devTeam.Name}");
                Console.WriteLine();
            }
            Console.WriteLine("Please select a DevTeamId to add a Developer to:");
            var devTeamId = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            List<Developer> developers = _developerRepo.GetDevelopers();
            foreach (Developer developer in developers)
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {developer.Id}");
                Console.WriteLine($"Name: { developer.Name}");
            }
            Console.WriteLine($"Please select a Developer ID that you would like to add to this Team: {devTeamId}");
            var developerId = Convert.ToInt32(Console.ReadLine());
            var isAdded = _devTeamRepo.AddDevToTeam(developerId, devTeamId);
            if (isAdded)
                Console.WriteLine("Additon Successful");
            else
                Console.WriteLine("Addition Failed");
        }
        public void ShowAllDevelopersOnTeam()
        {
            Console.Clear();
            List<DevTeam> developerTeams = _devTeamRepo.GetDevTeams();
            foreach (DevTeam devTeam in developerTeams)
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {devTeam.Id}");
                Console.WriteLine($"Name: { devTeam.Name}");
                Console.WriteLine();
            }
            Console.WriteLine("Please select the ID of the Team in which you would like to see all the Developers:");
            var devTeamId = Convert.ToInt32(Console.ReadLine());
            var foundDevTeam = _devTeamRepo.GetDevTeamById(devTeamId);
            var developers = foundDevTeam.Developers;
            foreach (var developer in developers)
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {developer.Id}");
                Console.WriteLine($"Name: { developer.Name}");
                Console.WriteLine();
            }
        }
    }
}