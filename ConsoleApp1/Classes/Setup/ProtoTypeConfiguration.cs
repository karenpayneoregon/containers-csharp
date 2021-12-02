using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp1.Classes.Setup
{
    public class ProtoTypeConfiguration
    {
        /// <summary>
        /// This class really belongs in another class project but to keep things
        /// simple it's in the same project.
        /// </summary>
        public static void CreateJson()
        {
            var data = new List<Settings>
            {
                new()
                {
                    Environment = "Development",
                    ReloadApplicationOnEveryRequest = true,
                    Reload = "reload",
                    Password = true,
                    ConnectionString = "",
                    DiConfiguration = new DiConfiguration()
                    {
                        Dsn = "OCS",
                        Globals = "globals",
                        Globals2 = "globals2",
                        MailTo = "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
                        ExitLink = "/ocs4/",
                        BaseServerAddress = "ocs4",
                        UseGeoLocation = true,
                        MfLink = "",
                        MfPass = "",
                        ResetPinLocation = "/ocs4/pinchange/index.cfm/main/begin/",
                        UirTakeTest = false,
                        QryCacheLong = new TimeSpan(0, 0, 0, 5),
                        QryCacheShort = new TimeSpan(0, 0, 0, 10)
                    }
                },
                new()
                {
                    Environment = "Test",
                    ReloadApplicationOnEveryRequest = false,
                    Reload = "reload",
                    Password = true,
                    ConnectionString = "",
                    DiConfiguration = new DiConfiguration()
                    {
                        Dsn = "OCS",
                        Globals = "globals",
                        Globals2 = "globals2",
                        MailTo = "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
                        ExitLink = "/ocs4/",
                        BaseServerAddress = "ocs4",
                        UseGeoLocation = true,
                        MfLink = "",
                        MfPass = "",
                        ResetPinLocation = "/ocs4/pinchange/index.cfm/main/begin/",
                        UirTakeTest = false,
                        QryCacheLong = new TimeSpan(0, 0, 1, 0),
                        QryCacheShort = new TimeSpan(0, 0, 10, 0)
                    }
                },
                new Settings()
                {
                    Environment = "Production",
                    ReloadApplicationOnEveryRequest = false,
                    Reload = "reload",
                    Password = true,
                    ConnectionString = "",
                    DiConfiguration = new DiConfiguration()
                    {
                        Dsn = "OCS",
                        Globals = "globals",
                        Globals2 = "globals2",
                        MailTo = "karen.1.payne@oregon.gov;fred.g.wenger@oregon.gov;bill.rickman@oregon.gov",
                        ExitLink = "/ocs4/",
                        BaseServerAddress = "ocs4",
                        UseGeoLocation = true,
                        MfLink = "",
                        MfPass = "",
                        ResetPinLocation = "/ocs4/pinchange/index.cfm/main/begin/",
                        UirTakeTest = false,
                        QryCacheLong = new TimeSpan(0, 0, 30, 0),
                        QryCacheShort = new TimeSpan(0, 6, 0, 0)
                    }
                }
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("Dump.txt", json);

            List<Settings> applicationSettingsList = JsonConvert.DeserializeObject<List<Settings>>(File.ReadAllText("Dump.txt"));
        }
    }
}
