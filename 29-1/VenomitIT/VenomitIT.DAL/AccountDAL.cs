using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
    public class AccountDAL : VenomitITEntityModel
    {
        public static User_Master GetUserInfo(String username)
        {
            User_Master user = (from u in VenomitITEntityModel.EntityModel.User_Master.Where(u => u.Username.ToLower() == username.ToLower())                      
                         select u).FirstOrDefault<User_Master>();
            return user;
        }
        public static User_Master GetWebUser(long UserID)
        {
            return EntityModel.User_Master.FirstOrDefault(x => x.UserId == UserID);
        }
        public static bool UpdatePassword(long userId, string oldPassword, string newPassword)
        {
            User_Master user = UserDAL.Get(x => x.UserId == userId && x.Password == oldPassword);
            if (user == null)
            {
                return false;
            }
            user.Password = newPassword;
            UserDAL.Update(user);
            return true;
        }
        public static User_Master GetClientByEmail(string email)
        {
            return EntityModel.User_Master.FirstOrDefault(x => x.Email == email);
        }
        public static User_Master UpdateEmailPassword(long userId, string password)
        {
            User_Master user = UserDAL.Get(x => x.UserId == userId);
            if (user == null)
                throw new Exception("User Not Found");
            user.Password = password;
            UserDAL.Update(user);

            return user;
        }

    }
}
