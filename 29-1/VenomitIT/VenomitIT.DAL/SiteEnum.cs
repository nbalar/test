using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public enum UserType
    {
        Admin = 1,
        Guest = 2

    }
    public enum UserLoginStatus
    {
        IncompleteInfo = 1,
        WrongUsernamePassword = 2,
        AccountVerfied = 3
    }
}
