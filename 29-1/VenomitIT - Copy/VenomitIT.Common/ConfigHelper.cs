using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace VenomitIT.Common
{
    public class ConfigHelper
    {
        public static String AdoConnstring
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConfigKey.AdoConnstring].ConnectionString;
            }
        }

        public static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConfigKey.ConnectionString].ConnectionString;
            }
        }

        public static String SiteImagePath
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.SiteImagePath];
            }
        }

        public static String JavaScriptPath
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.JavaScriptPath];
            }
        }

        public static String SiteCssPath
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.SiteCssPath];
            }
        }

        public static String SiteUrlPath
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.SiteUrlPath];
            }
        }

        public static String CookieDomain
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.CookieDomain];
            }
        }
        public static String Version
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.Version];
            }
        }

        public static String DocumentFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.DocumentFilePath];
            }
        }

        public static String DropFolder
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.DropFolder];
            }
        }
        public static String AdminEmailID
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.AdminEmailID];
            }
        }

        public static String DocumentAdminEmailID
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.DocumentAdminEmailID];
            }
        }
        public static String SMTP_Server
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.SMTP_Server];
            }
        }

        public static String SMTP_Username
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.SMTP_Username];
            }
        }

        public static String SMTP_Password
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.SMTP_Password];
            }
        }

        public static Int32 SMTP_Port
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings[ConfigKey.SMTP_Port]);
            }
        }
        public static String SiteUploadImagePath
        {
            get
            {
                return ConfigurationManager.AppSettings[ConfigKey.SiteUploadImagePath];
            }
        }
    }
}
