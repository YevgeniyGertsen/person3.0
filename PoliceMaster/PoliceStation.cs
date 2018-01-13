using MasterPeople;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceMaster
{
    public class PoliceStation
    {
        public string NamePoliceStation { get; set; }
        public int CodePoliceStation { get; set; }
        public string Address { get; set; }
        public City city { get; set; }

        public List<PolicePeolple> policePeolple = new List<PolicePeolple>();
    }
}
