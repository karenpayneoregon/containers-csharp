using System;
using System.Collections.Generic;

namespace ConsoleApp1.Classes
{
    public sealed class ApplicationSettings
    {
        private static readonly Lazy<ApplicationSettings> Lazy = new(() => new ApplicationSettings());
        
        private static string _dsn;
        private static string _environment;

        private static List<string> _mailAddress;
        private static TimeSpan _qryCacheShort;
        private static DiConfiguration _configuration;

        private ApplicationSettings()
        {
            Settings settings = Helper.GetApplicationSettings();

            _dsn = settings?.DiConfiguration.Dsn;
            _environment = settings?.Environment ?? "Development";
            _mailAddress = settings.MailAddressesList;
            _qryCacheShort = settings.DiConfiguration.QryCacheShort;
            _configuration = settings?.DiConfiguration;
        }

        
        /// <summary>
        /// Access point to methods and properties
        /// </summary>
        public static ApplicationSettings Instance => Lazy.Value;
        public string Dsn => _dsn;
        /// <summary>
        /// Current environment
        /// </summary>
        public string Environment => _environment;
        /// <summary>
        /// Mail addresses for sending email messages for exceptions
        /// </summary>
        public List<string> MailAddresses => _mailAddress;
        /// <summary>
        /// Short query time out
        /// </summary>
        public TimeSpan QryCacheShort => _qryCacheShort;

        public DiConfiguration Configuration => _configuration;
    }
}
