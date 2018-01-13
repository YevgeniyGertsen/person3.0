using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterPeople;
using PoliceMaster;


namespace SmartCity
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyMaster am = new AssemblyMaster();

            #region CityService
            am.PathCityService = @"\\dc\Студенты\ПКО\PMP-162.1\SmartCity\CityService.soap";

            CityService cs = new CityService();
            cs.CodeSrevice = 102;
            cs.NameService = "Полиция";

            //am.CreateCityService(cs);
            #endregion

            #region 
            am.PathCity = @"\\dc\Студенты\ПКО\PMP-162.1\SmartCity\City.soap";

            City city = new City();
            city.Area = 300629;
            city.Population = 834813;
            city.CityName = "Ақтөбе";
            city.CityServices = new List<CityService>() { cs };

            //am.CreateCity(city);
            #endregion

            #region Region
            am.PathRegion = @"\\dc\Студенты\ПКО\PMP-162.1\SmartCity\Region.soap";

            Region region = new Region();
            region.MainCity = city;
            region.Population = 834813;
            region.RegionCites = null;
            region.RegionName = "Актюбинская область";

            //am.CreateRegion(region);
            #endregion

            MasterPolice pm = new MasterPolice();
            pm.PathPoliceStation = @"\\dc\Студенты\ПКО\PMP-162.1\SmartCity\PoliceStation.soap";
            PoliceStation ps = new PoliceStation();
            ps.Address = "Темирязе 31";
            ps.city = am.GetCity()[0];
            ps.CodePoliceStation = 001;
            ps.NamePoliceStation = "Темирязева";

            pm.CreatePoliceStation(ps);
        }
    }
}
