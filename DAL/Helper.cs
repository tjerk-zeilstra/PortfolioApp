using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace DAL
{
    public static class Helper
    {
        public static string ConString(IConfigurationBuilder configurationBuilder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            var appSettings = root.GetSection("ConnectionStrings:DefaultConnection");
            return appSettings.Value;
        }
    }
}
