using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace BunnyEscape.Handlers
{
    public class GeolocationHandler
    {
        public async Task<string> GetCountryName()
        {
            var geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 100;

            Geoposition position = await geolocator.GetGeopositionAsync();

            // reverse geocoding
            BasicGeoposition myLocation = new BasicGeoposition
            {
                Longitude = position.Coordinate.Longitude,
                Latitude = position.Coordinate.Latitude
            };
            Geopoint pointToReverseGeocode = new Geopoint(myLocation);

            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            if (result == null)
            {
                return "";
            }

            string country = result.Locations[0].Address.Country;
            return country;
        }
    }
}
