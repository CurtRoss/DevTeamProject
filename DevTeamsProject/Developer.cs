using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        private static int count = 0;
        public string DeveloperName { get; set; }
        public int IdentificationNumber { get; set; }
        public bool AccessPluralsight { get; set; }
        
        
        public Developer()
        {
            count++;
            IdentificationNumber = count;
        }

        
        public Developer(string developerName, bool accessPluralsight)
        {
            DeveloperName = developerName;
            count++;
            IdentificationNumber = count;
            AccessPluralsight = accessPluralsight;
        }
    }

}