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
    public class WhyWeController : Controller
    {
        //
        // GET: /WhyWe/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageWhyWe(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            WhyWeModel model = new WhyWeModel();
            if (domainId > 0)
            {

                model.whyweList = WhyWeBLL.Getwhywelist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }
        public ActionResult AddWhyWe(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditWhyWeModel model = new EditWhyWeModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditWhyWe", model);
        }
        [HttpPost]
        public ActionResult AddWhyWe(EditWhyWeModel model)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (ModelState.IsValid)
            {
                WhyWeBLL.SaveWhyWeDetails(model);
                WhyWeModel whyWeModel = new WhyWeModel();
                whyWeModel.whyweList = WhyWeBLL.Getwhywelist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageWhyWe, model.DomainId));
                return View("ManageWhyWe", whyWeModel);
            }
            else
            {
                return View("EditWhyWe", model);
            }

        }

        public ActionResult EditWhyWe(Int64 whyweId)
        {
            EditWhyWeModel editWhyWeModel = new EditWhyWeModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (whyweId > 0)
            {
                ViewBag.msg = "Edit Why We";
                editWhyWeModel = WhyWeBLL.getWhyweById(whyweId);
            }

            return View(editWhyWeModel);
        }
        [HttpPost]
        public ActionResult EditWhyWe(EditWhyWeModel model)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (ModelState.IsValid)
            {

                WhyWeBLL.SaveWhyWeDetails(model);
                WhyWeModel whyWeModel = new WhyWeModel();
                whyWeModel.whyweList = WhyWeBLL.Getwhywelist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageWhyWe, model.DomainId));
                return View("ManageWhyWe", whyWeModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteWhyWe(Int64 whyweId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditWhyWeModel model = new EditWhyWeModel();
            if (whyweId > 0)
            {
                model = WhyWeBLL.getWhyweById(whyweId);
            }
            if (WhyWeBLL.DeleteWhywe(whyweId))
            {
                WhyWeModel whyWeModel = new WhyWeModel();
                whyWeModel.whyweList = WhyWeBLL.Getwhywelist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageWhyWe, model.DomainId));
                return View("ManageWhyWe", whyWeModel);
            }
            return View("ManageWhyWe");

        }

    }
}
