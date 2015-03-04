using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenomitIT.Common;
using VenomitIT.DAL;
using VenomitIT.BLL;

namespace VenomitIT.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.AdminHomePage);
            }

            return View(new SignInModel { });
        }

        [HttpPost]
        public ActionResult Index(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                UserLoginStatus userLoginStatus = AccountBLL.IsValidUser(model);
                if (userLoginStatus == UserLoginStatus.AccountVerfied)
                {
                    User_Master user = AccountBLL.GetWebUser(model.UserID);
                    if (user.UserType == (Byte)UserType.Admin)
                    {
                        AccountBLL.CreateUserCookie(model);

                        Response.Redirect(NavigationURL.AdminHomePage);
                    }

                }
                else
                {
                    model.LoginErrorMsg = "Invalid username or password";
                }
            }
            return View(model);
        }
        public ActionResult DashBoard()
        {
            return View();
        }

    }
}
