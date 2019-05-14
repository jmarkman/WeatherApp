using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI
{
    /// <summary>
    /// Ways to search for a certain location
    /// </summary>
    // TODO: Add a mutli-type search?
    public class ClientEnums
    {
        public enum By
        {
            CityName,
            CityID,
            LatLong,
            ZipCode
        }
    }
}
