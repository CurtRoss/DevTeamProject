using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevTeamsProject_Console
{
    public class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        // Method that runs/starts the app

        public void Run()
        {
            SeedDeveloperList();
            Menu();
        }

        // Menu

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a Menu option:\n" +
                    "1. Enter Developer into Pool of Developers\n" +
                    "2. Display Developer by ID#\n" +
                    "3. Update Developer Info\n" +
                    "4. Display List of Developers\n" +
                    "5. Show List of Developers Who Need Pluralsight License\n" +
                    "6. Delete Existing Developer\n" +
                    "************************************************************\n" +
                    "Teams Options\n" +
                    "7. Add Developer Team\n" +
                    "8. Assign Developer to Developer Team\n" +
                    "9. Display All Teams\n" +
                    "10. Remove Developer from Team\n" +
                    "11. Add multiple Developers to Team\n" +
                    "12. Display Developers from a Particular Team\n" +
                    "13. Exit Application.");
                   
                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Enter Developer into Pool of Developers
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // Display Developer by ID#
                        DisplayDevelopersByID();
                        break;
                    case "3":
                        // Update Developer Info
                        UpdateExistingDeveloper();
                        break;
                    case "4":
                        // Display List of Developers
                        DisplayAllDevelopers();
                        break;
                    case "5":
                        // Show List of Developers Who Need Pluralsight License
                        DisplayAllDevelopersThatNeedLicense();
                        break;
                    case "6":
                        // Delete Existing User
                        DeleteExistingDeveloper();
                        break;
                    case "7":
                        // Add Developer Team to list of Developer Teams
                        AddDeveloperTeam();
                        break;
                    case "8":
                        // Assign Developer to Developer Team
                        AddDeveloperToTeam();
                        break;
                    case "9":
                        // Display All Teams
                        DisplayAllTeams();
                        break;
                    case "10":
                        // Remove Developer from a Team
                        RemoveDeveloperFromTeam();
                        break;
                    case "11":
                        // Add Multiple Developers to a Team
                        AddMultipleDeveloperToTeam();
                        break;
                    case "12":
                        // Display Developers on a chosen team
                        ListDevelopersFromSelectedTeam();
                        break;
                    case "13":
                        // Exit
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid Number.");
                        break;

                }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create new Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            //Developer Name
            Console.WriteLine("Enter the name of the Developer");
            newDeveloper.DeveloperName = Console.ReadLine();


            //Does Developer Have PluralSight
            Console.WriteLine("Does this Developer have PluralSight License?\n" +
                "Y/N?");
            string pluralSightYN = Console.ReadLine().ToLower();
            string answer = "y";
            if (pluralSightYN.Contains(answer))
            {
                newDeveloper.AccessPluralsight = true;
            }
            else
            {
                newDeveloper.AccessPluralsight = false;
            }
            _developerRepo.AddDeveloperToList(newDeveloper);
        }


        // View Existing Developer by ID#
        private void DisplayDevelopersByID()
        {
            Console.Clear();
            //Prompt user to give ID#
            Console.WriteLine("Enter the ID # of the Developer you would like to see");

            //get the user's input
            string developerIDAsString = Console.ReadLine();
            int developerID = int.Parse(developerIDAsString);

            // Find the developer by ID #
            Developer developer = _developerRepo.GetDeveloperByIdentification(developerID);

            //Display said Developer if it isn't null

            if (developer != null)
            {
                Console.WriteLine($"Name: {developer.DeveloperName}\n" +
                    $" ID number: {developer.IdentificationNumber}\n" +
                    $" Licensed in PluralSight: {developer.AccessPluralsight}");
            }
            else
            {
                Console.WriteLine($"No Developer with ID# {developerID}");
            }
        }
        

        // Update Developers info 
        private void UpdateExistingDeveloper()
        {

            //Display all Developers
            DisplayAllDevelopers();
            // Ask for Developer to update
            Console.WriteLine("Enter the Developer ID of the Developer you want to update");
            //get that developer
            int oldID = int.Parse(Console.ReadLine());
            //build new object
            Console.Clear();
            Developer newDeveloper = new Developer();

            //name
            Console.WriteLine("Enter the name for the Developer");
            newDeveloper.DeveloperName = Console.ReadLine();
            //has pluralsight
            Console.WriteLine("Does this developer have access to PluralSight? (y/n)");
            string accessPluralsight = Console.ReadLine().ToLower();

            if (accessPluralsight.Contains("y"))
            {
                newDeveloper.AccessPluralsight = true;
            }
            else
            {
                newDeveloper.AccessPluralsight = false;
            }

            //verify it worked
            bool wasUpdated = _developerRepo.UpdateExistingDeveloper(oldID, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer Successfully updated");
            }
            else
            {
                Console.WriteLine("Could not Update Developer");
            }

        }


        // Delete Developer from Developer List
        private void DeleteExistingDeveloper()
        {
            DisplayAllDevelopers();

            //Get the ID# of the Developer they want to remove
            Console.WriteLine("Enter the ID # of the Developer you would like to Delete.");

            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);

            //Call Delete Method
            bool wasDeleted = _developerRepo.DeleteDeveloperByIdentificationNumber(input);

            // If content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The developer could not be deleted.");
            }

        }


        // Display all Developers in list.
        private List<Developer> DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developer> developerList = _developerRepo.GetDeveloperList();
            foreach(Developer developer in developerList)
            {
                Console.WriteLine($"Name: {developer.DeveloperName}\n" +
                    $"Developer ID: {developer.IdentificationNumber}\n" +
                    $"Has License for PluralSight {developer.AccessPluralsight}");
            }
            return developerList;
        }


        // Display List of Developers who need their PluralSight License
        private void DisplayAllDevelopersThatNeedLicense()
        {
            Console.Clear();
            List<Developer> listOfDevs = _developerRepo.GetDeveloperList();
            foreach(Developer developer in listOfDevs)
            {
                if(developer.AccessPluralsight == false)
                {
                    Console.WriteLine(developer.DeveloperName + " needs their license");
                }
            }

        }


        // Add Developer Team
        private void AddDeveloperTeam()
        {
            Console.Clear();

            DevTeam newTeam = new DevTeam();

            //Add Dev Team name
            Console.WriteLine("Enter the name for the new Developer Team");
            newTeam.DevTeamName = Console.ReadLine();

            // Assign group number to Dev Team
            Console.WriteLine("Enter the group number you want to assign to this team");
            newTeam.GroupNumber = int.Parse(Console.ReadLine());

            newTeam.ListOfDevelopers = new List<Developer>();

            // Add dev team to devteam repo 
            _devTeamRepo.AddNewTeamToList(newTeam);
        }

        // Display all Teams
        private void DisplayAllTeams()
        {
            Console.Clear();

            List<DevTeam> listOfTeams = _devTeamRepo.GetTeamList();
          
            foreach(DevTeam devTeam in listOfTeams)
            {
                Console.WriteLine($"Developer Team Number: {devTeam.GroupNumber}\n" +
                $"Developer Team Name: {devTeam.DevTeamName}\nThese are the Developers on this team:\n");

                    for (int i = 0; i < devTeam.ListOfDevelopers.Count; i++)
                    {
                        Console.WriteLine($"{devTeam.ListOfDevelopers[i].DeveloperName}");
                    }
                Console.WriteLine("\n\n");    

            }
        }
        

        //Assign Developer to Developer Team
        private void AddDeveloperToTeam()
        {
            //Display team choices 
            Console.WriteLine("Select which team you would like to add developer to (please enter their group number and hit enter)");

            DisplayAllTeams();

            //select which team number to add developer to
            int teamSelectionAsInt = int.Parse(Console.ReadLine());
            DevTeam teamSelection = _devTeamRepo.GetTeamByGroupNumber(teamSelectionAsInt);

            Console.WriteLine($"Select which developer you would like to add to the team {teamSelection.DevTeamName}");

            //Display list of developers and prompt user to select developer by ID#


            List <Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine(developer.IdentificationNumber.ToString() + ". " + developer.DeveloperName);
            }

            int developerSelection = int.Parse(Console.ReadLine());
            Developer developerToAdd = _developerRepo.GetDeveloperByIdentification(developerSelection);

            // Check to see if chosen developer is already on that team

            //if (developerToAdd.IdentificationNumber != ); 


            //Add Developer to Team
            teamSelection.ListOfDevelopers.Add(developerToAdd);

        }


        //Remove Developer from Team
        private void RemoveDeveloperFromTeam()
        {
            //Display team choices and take input
            Console.WriteLine("Select which team you would like to delete developer from (please enter their group number and hit enter)\n");

            DisplayAllTeams();

            //Display members of that team

            int teamSelectionAsInt = int.Parse(Console.ReadLine());
            DevTeam teamSelection = _devTeamRepo.GetTeamByGroupNumber(teamSelectionAsInt);

            foreach (Developer developer in teamSelection.ListOfDevelopers)
            {
                Console.WriteLine(developer);
            }


            //Take users input
            Console.WriteLine($"Select which developer you would like to remove from the team {teamSelection.DevTeamName}");

            //Delete user from that team
            int developerIDToDelete = int.Parse(Console.ReadLine());
            Developer developerToDeleteFromTeam = _developerRepo.GetDeveloperByIdentification(developerIDToDelete);
            teamSelection.ListOfDevelopers.Remove(developerToDeleteFromTeam);
        }


        //Add Multiple users to a team
        private void AddMultipleDeveloperToTeam()
        {
            //Display team choices 
            Console.WriteLine("Select which team you would like to add developer to (please enter their group number and hit enter)");

            DisplayAllTeams();

            //select which team number to add developer to
            int teamSelectionAsInt = int.Parse(Console.ReadLine());
            DevTeam teamSelection = _devTeamRepo.GetTeamByGroupNumber(teamSelectionAsInt);

            // code to be repeated (while loop)
            Console.WriteLine("How many users would you like to add?");

            int i = 1;
            int howManyDevelopers = int.Parse(Console.ReadLine());
            while (i <= howManyDevelopers)
            {
            Console.WriteLine($"Select which developer you would like to add to the team {teamSelection.DevTeamName}");

            //Display list of developers and prompt user to select developer by ID#


            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine(developer.IdentificationNumber.ToString() + ". " + developer.DeveloperName);
            }

            int developerSelection = int.Parse(Console.ReadLine());
            Developer developerToAdd = _developerRepo.GetDeveloperByIdentification(developerSelection);

            //Add Developer to Team
            teamSelection.ListOfDevelopers.Add(developerToAdd);
            i++;

            //Console.WriteLine("Would you like to add another user? input 'y' to add another user");
            //string answer = Console.ReadLine();
            }

        }


        //Display Developers on a Chosen Team
        private void ListDevelopersFromSelectedTeam()
        {
            //List the teams and then ask the user for input
            DisplayAllTeams();

            //Display list of developer names for the team.
            int teamSelectionAsInt = int.Parse(Console.ReadLine());
            DevTeam teamSelection = _devTeamRepo.GetTeamByGroupNumber(teamSelectionAsInt);

            foreach (Developer developer in teamSelection.ListOfDevelopers)
            {
                Console.WriteLine(developer.DeveloperName);
            }
        }


        //Seed method
        private void SeedDeveloperList()
        {
            Developer jackJohnson = new Developer("Jack Johnson", false);
            Developer keithSweat = new Developer("Keith Sweat", true);
            Developer johnMayer = new Developer("John Mayer", true);

            _developerRepo.AddDeveloperToList(jackJohnson);
            _developerRepo.AddDeveloperToList(keithSweat);
            _developerRepo.AddDeveloperToList(johnMayer);

            DevTeam scoutTeamList = new DevTeam();
            scoutTeamList.DevTeamName = "Scout Team";
            scoutTeamList.ListOfDevelopers.Add(jackJohnson);
            scoutTeamList.ListOfDevelopers.Add(keithSweat);
            _devTeamRepo.AddNewTeamToList(scoutTeamList);
           
            DevTeam specialTeamList = new DevTeam();
            specialTeamList.DevTeamName = "Special Team";
            specialTeamList.ListOfDevelopers.Add(johnMayer);


            _devTeamRepo.AddNewTeamToList(specialTeamList);

        }

       





    }
}
