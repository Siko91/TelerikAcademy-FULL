using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace BunnyEscape.Handlers
{
    public class GeolocationHandler
    {
        public async Task<string> GetCountryName()
        {
            // windows store app doesn't support this the same way as windows phone apps.
            // TODO: Find another way!
            return "";
        }
    }
}
