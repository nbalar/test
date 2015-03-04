
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
    public class DomainController : Controller
    {
        //
        // GET: /Domain/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DomainDetails()
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            DomainModel model = new DomainModel();
            model.domainList = DomainBLL.Getdomainlist().ToList();
            return View(model);
        }

        public ActionResult AddDomain()
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditDomainModel model = new EditDomainModel();
            return View("EditDomain", model);
        }
        [HttpPost]
        public ActionResult AddDomain(EditDomainModel editDomainModel)
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

                DomainBLL.SaveDomainDetails(editDomainModel);
                cms_venomitEntities db = new cms_venomitEntities();
                var domainId = db.Domain_Master.OrderByDescending(d => d.DomainId).FirstOrDefault().DomainId;
                editDomainModel.DomainId = domainId;
                DomainBLL.SendRegisterDomainEmail(editDomainModel, this);
                DomainModel model = new DomainModel();
                model.domainList = DomainBLL.Getdomainlist().ToList();
                Response.Redirect(NavigationURL.ManageDomain);
                return View("DomainDetails", model);
            }
            else
            {
                return View("EditDomain", editDomainModel);
            }
        }

        public ActionResult EditDomain(Int64 domainId)
        {
            EditDomainModel editDomainModel = new EditDomainModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (domainId > 0)
            {
                ViewBag.msg = "Edit Domain";
                editDomainModel = DomainBLL.getDomainDetailsById(domainId);
            }

            return View(editDomainModel);
        }
        [HttpPost]
        public ActionResult EditDomain(EditDomainModel editDomainModel)
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
                DomainBLL.SaveDomainDetails(editDomainModel);
                DomainModel model = new DomainModel();
                model.domainList = DomainBLL.Getdomainlist().ToList();
                Response.Redirect(NavigationURL.ManageDomain);
                return View("DomainDetails", model);
            }
            else
            {
                return View("EditDomain", editDomainModel);
            }
        }
        //Delete Domain

        public ActionResult DeleteDomain(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (DomainBLL.DeleteDomains(domainId))
            {
                DomainModel model = new DomainModel();
                model.domainList = DomainBLL.Getdomainlist().ToList();
                return View("DomainDetails", model);
            }
            return View("DomainDetails");
        }


        //Manage Domain Content        
        public ActionResult DomainMange(Int64 domainId)
        {
            EditDomainModel model = new EditDomainModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (domainId > 0)
            {
                model = DomainBLL.getDomainDetailsById(domainId);
            }
            else
            {
                Response.Redirect(NavigationURL.AdminHomePage);
            }
            return View(model);
        }

    }
}
