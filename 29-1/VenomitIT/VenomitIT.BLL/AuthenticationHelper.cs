using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenomitIT.Common;
using VenomitIT.DAL;
namespace VenomitIT.Common
{
    public class AuthenticationHelper
    {
        public static Boolean IsLoggedIn
        {
            get
            {
                return true;
            }
            set
            {

            }
        }

        //public static String GetLeftNav()
        //{
        //    String layout = NavigationURL.GuestMasterPage;
        //    switch (GetLoggedInUserType())
        //    {
        //        case UserType.Admin:
        //            layout = NavigationURL.AdminLeftNav;
        //            break;
        //        case UserType.Subscriber:
        //            layout = NavigationURL.SubscriberLeftPanel;
        //            break;
        //        case UserType.Guest:
        //            layout = NavigationURL.GuestLeftNav;
        //            break;
        //    }
        //    return layout;
        //}

        public static String GetMasterLayout()
        {
            String layout = NavigationURL.MasterPage;
            switch (GetLoggedInUserType())
            {
                case UserType.Admin:
                    layout = NavigationURL.MasterPage;
                    break;

                case UserType.Guest:
                    layout = NavigationURL.MasterPage;
                    break;
            }
            return layout;
        }

        public static UserType GetLoggedInUserType()
        {
            Int32 useType;
            if (AuthenticationHelper.IsLoggedIn)
            {
                String userTypeValue = CookieHelper.GetCookieValue(CookieKeys.UserType);
                if (int.TryParse(userTypeValue, out useType))
                {
                    return (UserType)useType;
                }
                else
                {
                    CookieHelper.ClearLoginCookie();
                    return UserType.Guest;
                }
            }
            else
            {
                return UserType.Guest;
            }
        }

        public static Boolean IsAccessAllowed(UserType userType)
        {
            if (GetLoggedInUserType().Equals(userType))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
