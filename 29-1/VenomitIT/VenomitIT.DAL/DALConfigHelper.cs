using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace VenomitIT.DAL
{
    class DALConfigHelper
    {
        public static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DALConfigKey.ConnectionString].ConnectionString;
            }
        }

       
    }
}
