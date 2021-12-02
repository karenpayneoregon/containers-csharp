using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1.Classes
{
    public class Helper
    {
        private static string _dsn;
        private static DiConfiguration _configuration;

        /// <summary>
        /// Configuration file name to read from.
        /// </summary>
        public static string ConfigurationFileName { get; set; } = "appsettings.json";

        /// <summary>
        /// Return all settings for the current environment
        /// </summary>
        /// <remarks>
        /// This method may be called and ignore the return information and
        /// use the properties in this class instead.
        /// </remarks>
        public static Settings GetApplicationSettings()
        {
            IConfigurationRoot config = InitMainConfiguration();
            Settings current = config.GetSection("GeneralSettings").Get<List<Settings>>()
                .FirstOrDefault(setting => setting.Environment == Environment);

            _dsn = current?.DiConfiguration.Dsn;
            _configuration = current?.DiConfiguration;

            _mailAddress = current?.DiConfiguration.MailTo.Split(';').ToList();
            
            _qryCacheShort = current.DiConfiguration.QryCacheShort;

            Settings result = new (current.MailAddressesList, current);


            return result;

        }
        /// <summary>
        /// Current environment this application will run under
        /// </summary>
        public static string Environment {
            get
            {
                var config = InitMainConfiguration();
                return config.GetSection("Environment").Get<Environment>().Name;

            }
        }

        private static TimeSpan _qryCacheShort;
        /// <summary>
        /// Short time out for the application
        /// </summary>
        public static TimeSpan QryCacheShort => _qryCacheShort;

        public static DiConfiguration Configuration => _configuration;
        /// <summary>
        /// DSN used in the entire application
        /// </summary>
        public static string Dsn => _dsn;
        /// <summary>
        /// List of email addresses for sending on unhandled exceptions
        /// </summary>
        private static List<string> _mailAddress;
        public static List<string> MailAddress => _mailAddress;

        /// <summary>
        /// Initialize ConfigurationBuilder for appsettings
        /// </summary>
        /// <returns>IConfigurationRoot</returns>
        private static IConfigurationRoot InitMainConfiguration()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ConfigurationFileName);

            return builder.Build();

        }

       
    }
}
