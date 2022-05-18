using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServicoGatewayWeb.Integrations.Client.APIGateway
{
   /// <summary>
   /// Represents a set of configuration settings
   /// </summary>
   public class ConfigurationGateway
    {
  
        public const string Version = "1.0.0";

        public static String Username { get; set; }

        public static String Password { get; set; }

        public static Dictionary<String, String> ApiKey = new Dictionary<String, String>();

        public static Dictionary<String, String> ApiKeyPrefix = new Dictionary<String, String>();
  
        private static string _tempFolderPath = Path.GetTempPath();

        public static String TempFolderPath
        {
            get { return _tempFolderPath; }
  
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    _tempFolderPath = value;
                    return;
                }
      
                // create the directory if it does not exist
                if (!Directory.Exists(value)) 
                    Directory.CreateDirectory(value);
      
                // check if the path contains directory separator at the end
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                    _tempFolderPath = value;
                else
                    _tempFolderPath = value  + Path.DirectorySeparatorChar;
            }
        }

        private const string ISO8601_DATETIME_FORMAT = "o";

        private static string _dateTimeFormat = ISO8601_DATETIME_FORMAT;

        public static String DateTimeFormat
        {
            get
            {
                return _dateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        public static String ToDebugReport()
        {
            String report = "C# SDK (ServicoGatewayWeb.Integrations) Debug Report:\n";
            report += "    OS: " + Environment.OSVersion + "\n";
            report += "    .NET Framework Version: " + Assembly
                     .GetExecutingAssembly()
                     .GetReferencedAssemblies()
                     .Where(x => x.Name == "System.Core").First().Version.ToString()  + "\n";
            report += "    Version of the API: v1\n";
            report += "    SDK Package Version: 1.0.0\n";
  
            return report;
        }
    }
}
