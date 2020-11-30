using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        // Create field to hold all existing Developers
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToList(Developer developer)
        {
            _developerDirectory.Add(developer);
        }


        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }


        //Developer Update
        public bool UpdateExistingDeveloper(int originalIdentification, Developer newDeveloper)
        {
            //find the developer by ID
            Developer originalDeveloper = GetDeveloperByIdentification(originalIdentification);

            //update the Developer information
            if(originalDeveloper != null)
            {
                originalDeveloper.DeveloperName = newDeveloper.DeveloperName;
                originalDeveloper.IdentificationNumber = newDeveloper.IdentificationNumber;
                originalDeveloper.AccessPluralsight = newDeveloper.AccessPluralsight;

                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        //Developer Delete
        public bool DeleteDeveloperByIdentificationNumber(int identificationNumber)
        {
            Developer devToDelete = GetDeveloperByIdentification(identificationNumber);
            if(devToDelete == null)
            {
                return false;
            }
            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(devToDelete);

            if(initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByIdentification(int identificationNumber)
        {
            foreach(Developer developer in _developerDirectory)
            {
                if(developer.IdentificationNumber == identificationNumber)
                {
                    return developer;
                }
            }

            return null;
        }

    }
}
