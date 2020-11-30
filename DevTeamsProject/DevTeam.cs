using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        private static int count = 0;
        public string DevTeamName { get; set; }
        public int GroupNumber { get; set; }

        public List<Developer> ListOfDevelopers { get; set; }

        
        public DevTeam()
        {
            count++;
            GroupNumber = count;
            ListOfDevelopers = new List<Developer>();
        }

        public DevTeam(string devTeamName)
        {
            DevTeamName = devTeamName;
            count++;
            GroupNumber = count;
            ListOfDevelopers = new List<Developer>();
        }

        


    }
}
