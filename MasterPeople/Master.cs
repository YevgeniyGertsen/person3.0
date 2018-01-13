using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MasterPeople
{
    public class AssemblyMaster
    {
        #region Region
        /// <summary>
        /// Путь к файлу Регионов
        /// </summary>
        public string PathRegion { get; set; }

        /// <summary>
        /// Метод Создания региона
        /// </summary>
        /// <param name="region">Класс региона</param>
        /// <returns></returns>
        public bool CreateRegion(Region region)
        {
            List<Region> regions = GetRegion();
            regions.Add(region);

            XmlSerializer formatter = 
                new XmlSerializer(typeof(List<Region>));
            try
            {
                using (FileStream fs =
                new FileStream(PathRegion, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, regions);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public List<Region> GetRegion()
        {
            XmlSerializer formatter = 
                new XmlSerializer(typeof(List<Region>));

            List<Region> regions = new List<Region>();

            FileInfo fi = new FileInfo(PathRegion);
            if(fi.Exists)
            {
                using (FileStream fs = new FileStream(PathRegion, FileMode.OpenOrCreate))
                {
                    regions = (List<Region>)formatter.Deserialize(fs);
                }
            }

            return regions==null 
                ? new List<Region>()
                : regions;
        }
        #endregion

        #region City
        public string PathCity { get; set; }

        public bool CreateCity(City city)
        {
            List<City> cities = GetCity();
            cities.Add(city);

            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<City>));

            try
            {
                using (FileStream fs =
                new FileStream(PathCity, FileMode.OpenOrCreate))
                {
                    xmlFormatter.Serialize(fs, cities);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<City> GetCity()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<City>));
            List<City> cityes = new List<City>();

            FileInfo fi = new FileInfo(PathCity);
            if (fi.Exists)
            {
                using (FileStream fs =
                    new FileStream(PathCity, FileMode.OpenOrCreate))
                {
                    cityes = (List<City>)formatter.Deserialize(fs);
                }
            }

            return cityes == null
                ? new List<City>()
                : cityes;
        }
        #endregion

        #region CityService
        public string PathCityService { get; set; }

        public bool CreateCityService(CityService cityService)
        {
            List<CityService> cities = GetCityService();
            cities.Add(cityService);

            XmlSerializer formatter = new XmlSerializer(typeof(List<CityService>));
            try
            {
                using (FileStream fs =
                new FileStream(PathCityService, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, cities);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CityService> GetCityService()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<CityService>));
            List<CityService> cityService = new List<CityService>();

            FileInfo fi = new FileInfo(PathCityService);
            if (fi.Exists)
            {
                using (FileStream fs =
                    new FileStream(PathCityService, FileMode.OpenOrCreate))
                {
                    cityService = (List<CityService>)formatter.Deserialize(fs);
                }
            }

            return cityService == null
                ? new List<CityService>()
                : cityService;
        }
        #endregion
    }
}
