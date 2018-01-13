using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person;
using person.ModelHuman;

namespace PoliceMaster
{
    public class PolicePeolple : Adult
    {
        public PolicePeolple ()
        {
            IsWorking = true;
        }

        public string Rank { get; set; }
        public double Salary { get; set; }

    }
}
