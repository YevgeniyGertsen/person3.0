using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterPeople;
using System.Xml.Serialization;
using System.IO;

namespace PoliceMaster
{
    public class MasterPolice
    {
        AssemblyMaster am = new AssemblyMaster();
     
        //List<PoliceStation> PoliceStations 

        public void CreatePoliceStation()
        {
            PoliceStation ps = new PoliceStation();
            ps.Address = "";
            ps.city = am.GetCity()[0]; //cityPs
            ps.CodePoliceStation = 001;
            ps.NamePoliceStation = "";

            CreatePoliceStation(ps);
        }

        #region PoliceStation
        public string PathPoliceStation { get; set; }

        public bool CreatePoliceStation(PoliceStation policeStation, 
            List<PoliceStation> stations = null)
        {
            List<PoliceStation> policeStations = null;
            if (stations != null)
                policeStations = stations;
            else
            {
                policeStations = GetPoliceStation();
                policeStations.Add(policeStation);
            }


            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<PoliceStation>));

            try
            {
                using (FileStream fs =
                new FileStream(PathPoliceStation, FileMode.OpenOrCreate))
                {
                    xmlFormatter.Serialize(fs, policeStations);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<PoliceStation> GetPoliceStation()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<PoliceStation>));
            List<PoliceStation> cityes = new List<PoliceStation>();

            FileInfo fi = new FileInfo(PathPoliceStation);
            if (fi.Exists)
            {
                using (FileStream fs =
                    new FileStream(PathPoliceStation, FileMode.OpenOrCreate))
                {
                    cityes = (List<PoliceStation>)formatter.Deserialize(fs);
                }
            }

            return cityes == null
                ? new List<PoliceStation>()
                : cityes;
        }
        #endregion

        public void AddPolicePersonToStation(int codePs, PolicePeolple policePeople)
        {
            List<PoliceStation> poliseStations =
                GetPoliceStation();

            PoliceStation station =
                poliseStations.FirstOrDefault(
                    f => f.CodePoliceStation == codePs);
            //Извлекли станцию из списка
            poliseStations.Remove(station);
            //Изменили ее
            station.policePeolple.Add(policePeople);
            //Добавили снова
            poliseStations.Add(station);

            CreatePoliceStation(null, poliseStations);

        }
    }
}
