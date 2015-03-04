using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
   public class UserDAL: BaseDAL<User_Master>
    {
       public static User_Master GetUserById(int userid)
       {
           return EntityModel.User_Master.FirstOrDefault(x => x.UserId == userid);
       }
    }
}
