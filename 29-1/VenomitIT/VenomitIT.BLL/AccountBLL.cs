using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VenomitIT.DAL;
using VenomitIT.BLL;
using VenomitIT.Common;


namespace VenomitIT.BLL
{
    public class AccountBLL
    {
        public static UserLoginStatus IsValidUser(SignInModel model)
        {
            UserLoginStatus userLoginStatus;
            if (!model.Username.Trim().Equals(String.Empty) && !model.Password.Trim().Equals(String.Empty))
            {
                User_Master user = AccountDAL.GetUserInfo(model.Username);

                if (user != null)
                {
                    if (user.Password.Equals(model.Password))
                    {
                        model.Username = user.Username;
                        model.UserID = user.UserId;
                        model.UserTypeID = (Int32)user.UserType;
                        model.Fullname = user.FirstName + " " + user.LastName;
                        userLoginStatus = UserLoginStatus.AccountVerfied;
                    }
                    else
                    {
                        userLoginStatus = UserLoginStatus.WrongUsernamePassword;
                    }
                }
                else
                {
                    userLoginStatus = UserLoginStatus.WrongUsernamePassword;
                }
            }
            else
            {
                userLoginStatus = UserLoginStatus.IncompleteInfo;
            }
            SetLoginErrorMessage(model, userLoginStatus);
            return userLoginStatus;
        }
        public static void SetLoginErrorMessage(SignInModel model, UserLoginStatus userLoginStatus)
        {
            switch (userLoginStatus)
            {
                case UserLoginStatus.IncompleteInfo:
                    if (model.Username.Trim().Equals(String.Empty))
                    {
                        model.UsernameErrorMsg = "Enter a valid username";
                    }
                    if (model.Password.Trim().Equals(String.Empty))
                    {
                        model.UsernameErrorMsg = "Enter a valid password";
                    }
                    break;
                case UserLoginStatus.WrongUsernamePassword:
                    model.LoginErrorMsg = "Invalid username or password";
                    break;
            }
        }
        public static User_Master GetWebUser(long UserID)
        {
            return AccountDAL.GetWebUser(UserID);
        }

        public static Boolean ResetPassword(ChangePasswordModel changePasswordModel, Int64 userID)
        {
            return AccountDAL.UpdatePassword(userID, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
        }
        public static void CreateUserCookie(SignInModel model)
        {
            CookieHelper.SetCookie(CookieKeys.UserID, model.UserID.ToString());
            CookieHelper.SetCookie(CookieKeys.Username, model.Username.ToString());
            CookieHelper.SetCookie(CookieKeys.UserType, model.UserTypeID.ToString());
            CookieHelper.SetCookie(CookieKeys.Fullname, model.Fullname);
        }

        //Forgot password
        public static void ValidateAndSendPassword(ForgotPasswordModel forgotPasswordModel, Controller controller)
        {
            if (forgotPasswordModel.EmailId.Trim() != String.Empty)
            {
                User_Master user = AccountBLL.GetUserInfo(forgotPasswordModel);
                if (user != null)
                {
                    user.Password = GenerateRandomPassword();
                    AccountDAL.UpdateEmailPassword(user.UserId, user.Password);
                    SendPasswordEmail(user);
                    controller.ViewBag.ErrorMessage = "Your username has been emailed to you.  Please check your email for further instructions.";
                }
                else
                {
                    controller.ViewBag.EmailErrorMsg = "Email does not exists.";
                }
            }
            else
            {
                controller.ViewBag.UsernameErrorMsg = "Please enter Email.";
            }
        }
        public static User_Master GetUserInfo(ForgotPasswordModel forgotPassword)
        {
            User_Master user;
            user = AccountDAL.GetClientByEmail(forgotPassword.EmailId);
            return user;
        }

        //random password Generate
        private static string GenerateRandomPassword()
        {
            Random random = new Random();
            string specialCharacters = "!?$?%^&*()_-+={[}]:;@'~#|<,>.?/";
            string alphaCaps = "QWERTYUIOPASDFGHJKLZXCVBNM";

            char specialCharacter = specialCharacters[random.Next(specialCharacters.Count() - 1)];
            char alphaCapCharacter = alphaCaps[random.Next(alphaCaps.Length - 1)];

            string generatedPassword = Guid.NewGuid().ToString().Replace("-", "");

            //decreasing string length
            generatedPassword = generatedPassword.Remove(8);

            int specailCharacterindex = random.Next(generatedPassword.Length - 1);

            //Adding special character
            generatedPassword = generatedPassword.Insert(specailCharacterindex, specialCharacter.ToString());


            int alphaCharacterIndex = random.Next(generatedPassword.Length - 1);

            while (alphaCharacterIndex == specailCharacterindex)
            {
                alphaCharacterIndex = random.Next(generatedPassword.Length - 1);
            }

            //Adding cap character
            generatedPassword = generatedPassword.Insert(alphaCharacterIndex, alphaCapCharacter.ToString());

            return generatedPassword;
        }

        //Sent password To Email
        public static void SendPasswordEmail(User_Master user)
        {
            StringBuilder emailBody = new StringBuilder();
            emailBody.AppendLine("Hi" + CookieHelper.Fullname + "");
            emailBody.AppendLine("Password :" + user.Password + "");

          
            EmailUtility.SendEmail(ConfigHelper.AdminEmailID, user.Email, String.Empty, String.Empty, "Venom IT CMS Password", emailBody.ToString(), true, null);
        }
    }
}
