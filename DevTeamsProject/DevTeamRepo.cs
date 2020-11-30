using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
       
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        //DevTeam Create
        public void AddNewTeamToList(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        }


        //DevTeam Read
        public List <DevTeam> GetTeamList()
        {
            return _devTeams;
        }
       
        
        //DevTeam Update
        public bool UpdateExistingTeam(int teamNumber, DevTeam newDevTeam)
        {
            //find the developer team by group number
            DevTeam originalTeam = GetTeamByGroupNumber(teamNumber);

            //update the Developer Info
            if(originalTeam != null)
            {
                originalTeam.DevTeamName = newDevTeam.DevTeamName;
                originalTeam.GroupNumber = newDevTeam.GroupNumber;

                return true;
            }
            else
            {
                return false;
            }
        }
       
        
        //DevTeam Delete
        public bool DeleteDevTeamByGroupNumber(int groupNumber)
        {
            DevTeam devTeamtoDelete = GetTeamByGroupNumber(groupNumber);
            if(devTeamtoDelete == null)
            {
                return false;
            }
            int initialCount = _devTeams.Count;
            _devTeams.Remove(devTeamtoDelete);

            if(initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamByGroupNumber(int teamNumber)
        {
            foreach(DevTeam devTeam in _devTeams)
            {
                if(devTeam.GroupNumber == teamNumber)
                {
                    return devTeam;
                }
            }
            return null;
        }


    }
}
