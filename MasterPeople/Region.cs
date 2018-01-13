using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPeople
{
    [Serializable]
    public class Region
    {
        public string RegionName { get; set; }
        public City MainCity { get; set; }
        public List<City> RegionCites { get; set; }
        public int Population { get; set; }
    }
}
