using System;

namespace ConsoleApp1.Classes
{
    public class DiConfiguration
    {
        public string Dsn { get; init; }
        public string Globals { get; init; }
        public string Globals2 { get; init; }
        public string MailTo { get; init; }
        /// <summary>
        /// Exit link address
        /// </summary>
        public string ExitLink { get; init; }
        /// <summary>
        /// Application main page
        /// </summary>
        public string OcsLink { get; init; }
        public string MfLink { get; init; }
        public string MfUser { get; init; }
        public string MfPass { get; init; }
        /// <summary>
        /// Indicates whither to store client's geo location  
        /// </summary>
        public bool UseGeoLocation { get; init; }
        /// <summary>
        /// Reset pin page
        /// </summary>
        public string ResetPinLocation { get; init; }
        /// <summary>
        /// Base server address
        /// </summary>
        public string BaseServerAddress { get; init; }
        /// <summary>
        /// Indicates if test should be taken
        /// </summary>
        public bool UirTakeTest { get; init; }
        /// <summary>
        /// db query short cache expiration
        /// </summary>
        public TimeSpan QryCacheShort { get; init; }
        /// <summary>
        /// db query long cache expiration
        /// </summary>
        public TimeSpan QryCacheLong { get; init; }
    }
}