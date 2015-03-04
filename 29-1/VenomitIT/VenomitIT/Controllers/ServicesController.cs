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
    public class ServicesController : Controller
    {
        //
        // GET: /Plan/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageService(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            ServiceModel model = new ServiceModel();
            if (domainId > 0)
            {

                model.serviceList = ServiceBLL.Getserviceslist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }

        public ActionResult AddService(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditServiceModel model = new EditServiceModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditService", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddService(EditServiceModel model)
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
                ServiceBLL.SaveServiceDetails(model);
                ServiceModel serviceModel = new ServiceModel();
                serviceModel.serviceList = ServiceBLL.Getserviceslist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageService, model.DomainId));
                return View("ManageService", serviceModel);
            }
            else
            {
                return View("EditService", model);
            }

        }

        public ActionResult EditService(Int64 serviceId)
        {
            EditServiceModel editServiceModel = new EditServiceModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (serviceId > 0)
            {
                ViewBag.msg = "Edit Service";
                editServiceModel = ServiceBLL.getServiceById(serviceId);                
            }

            return View(editServiceModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditService(EditServiceModel model)
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

                ServiceBLL.SaveServiceDetails(model);
                ServiceModel serviceModel = new ServiceModel();
                serviceModel.serviceList = ServiceBLL.Getserviceslist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageService, model.DomainId));
                return View("ManageService", serviceModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteService(Int64 serviceId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditServiceModel model = new EditServiceModel();
            if (serviceId > 0)
            {
                model = ServiceBLL.getServiceById(serviceId);
            }
            if (ServiceBLL.DeleteServices(serviceId))
            {
                ServiceModel serviceModel = new ServiceModel();
                serviceModel.serviceList = ServiceBLL.Getserviceslist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageService, model.DomainId));
                return View("ManageService", serviceModel);
            }
            return View("ManageService");

        }
    }
}
