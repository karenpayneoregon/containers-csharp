using System.Collections.Generic;

namespace ConsoleApp1.Classes
{
    /// <summary>
    /// Container for application settings read using Helper class
    /// </summary>
    public class Settings
    {
        public string Environment { get; set; }
        public bool ReloadApplicationOnEveryRequest { get; set; }
        public bool Trace { get; init; }
        public string Reload { get; init; }
        public bool Password { get; init; }
        public string ConnectionString { get; init; }
        public List<string> MailAddressesList { get; init; }
        public DiConfiguration DiConfiguration { get; init; }

        public Settings()
        {
            DiConfiguration = new DiConfiguration();
        }

        /// <summary>
        /// Constructor setup to keep properties readonly 
        /// </summary>
        /// <param name="mailAddressesList">mail list read from appsettings</param>
        /// <param name="settings">All settings for the current environment</param>
        public Settings(List<string> mailAddressesList, Settings settings)
        {
            DiConfiguration = new DiConfiguration();

            MailAddressesList = mailAddressesList;
            Environment = settings.Environment;
            ReloadApplicationOnEveryRequest = settings.ReloadApplicationOnEveryRequest;
            Trace = settings.Trace;
            Reload = settings.Reload;
            Password = settings.Password;
            ConnectionString = settings.ConnectionString;
            DiConfiguration = settings.DiConfiguration;
        }

        public override string ToString() => Environment;
    }
}
