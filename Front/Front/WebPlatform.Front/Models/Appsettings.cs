using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPlatform.Front.Models
{
    public class Appsettings
    {
        public string APIContextPaht { get; set; }
    }

    public class AppsettingsConfigure : IAppsettingsConfigure
    {
        private readonly IConfiguration _configuration;

        public AppsettingsConfigure(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Appsettings GetAppsettings()
        {
            return AppsettingsPoint.GetAppsettings(_configuration);
        }
    }

    public static class AppsettingsPoint
    {
        public static Appsettings GetAppsettings(IConfiguration configuration)
        {
            var appsettings = new Appsettings();
            configuration.GetSection("Appsettings").Bind(appsettings);
            return appsettings;
        }
    }
}
