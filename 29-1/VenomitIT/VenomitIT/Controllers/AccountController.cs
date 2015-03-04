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
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (AccountBLL.ResetPassword(model, CookieHelper.UserID))
            {
                ViewBag.SuccessMessage = "Your Password updated succesfully.";
            }
            else
            {
                ViewBag.Errormessage = "Password Not Updated.";
            }

            return View(model);
        }
        public ActionResult SignOut()
        {
            CookieHelper.ClearLoginCookie();
            Session.Abandon();
            return RedirectToRoute("Home");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                AccountBLL.ValidateAndSendPassword(model, this);

            }
            return View("ForgotPassword", model);
        }
    }
}
