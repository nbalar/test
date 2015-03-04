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
    public class PricingController : Controller
    {
        //
        // GET: /Pricing/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagePricing(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            PricingModel model = new PricingModel();
            if (domainId > 0)
            {

                model.pricingList = PricingBLL.Getpricinglist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }

        public ActionResult AddPricing(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditPricingModel model = new EditPricingModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditPricing", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPricing(EditPricingModel model)
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
                PricingBLL.SavePricingDetails(model);
                PricingModel pricingModel = new PricingModel();
                pricingModel.pricingList = PricingBLL.Getpricinglist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManagePricing, model.DomainId));
                return View("ManagePricing", pricingModel);
            }
            else
            {
                return View("EditPricing", model);
            }

        }

        public ActionResult EditPricing(Int64 pricingId)
        {
            EditPricingModel editPricingModel = new EditPricingModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (pricingId > 0)
            {
                ViewBag.msg = "Edit Pricing";
                editPricingModel = PricingBLL.getPricingById(pricingId);
            }

            return View(editPricingModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPricing(EditPricingModel model)
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

                PricingBLL.SavePricingDetails(model);
                PricingModel pricingModel = new PricingModel();
                pricingModel.pricingList = PricingBLL.Getpricinglist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManagePricing, model.DomainId));
                return View("ManagePricing", pricingModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeletePricing(Int64 pricingId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditPricingModel model = new EditPricingModel();
            if (pricingId > 0)
            {
                model = PricingBLL.getPricingById(pricingId);
            }
            if (PricingBLL.DeletePricing(pricingId))
            {
                PricingModel pricingModel = new PricingModel();
                pricingModel.pricingList = PricingBLL.Getpricinglist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManagePricing, model.DomainId));
                return View("ManagePricing", pricingModel);
            }
            return View("ManagePricing");

        }


        //Mange Pricing details

        public ActionResult ManagePricingContent(Int64 pricingId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            PricingDetailsModel model = new PricingDetailsModel();
            if (pricingId > 0)
            {

                model.pricingdetailsList = PricingDetailsBLL.Getpricingdetailslist(pricingId).ToList();
                model.PricingId = pricingId;
                model.DomainId = PricingBLL.getPricingById(pricingId).DomainId;
            }

            return View(model);
        }

        public ActionResult AddPricingContent(Int64 pricingId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditPricingDetailsModel model = new EditPricingDetailsModel();
            if (pricingId > 0)
            {
                model.PricingId = pricingId;
                model.DomainId = PricingBLL.getPricingById(pricingId).DomainId;
            }
            return View("EditPricingContent", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPricingContent(EditPricingDetailsModel model)
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
                PricingDetailsBLL.SavePricingDetails(model);
                PricingDetailsModel pricingDetailsModel = new PricingDetailsModel();
                pricingDetailsModel.pricingdetailsList = PricingDetailsBLL.Getpricingdetailslist(model.PricingId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManagePricingContent, model.PricingId));
                return View("ManagePricingContent", pricingDetailsModel);
            }
            else
            {
                return View("EditPricingContent", model);
            }

        }


        public ActionResult EditPricingContent(Int64 pricingDetailsId)
        {
            EditPricingDetailsModel editPricingDetailsModel = new EditPricingDetailsModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (pricingDetailsId > 0)
            {
                ViewBag.msg = "Edit About Content";
                editPricingDetailsModel = PricingDetailsBLL.getPricingDetailsById(pricingDetailsId);
                editPricingDetailsModel.DomainId = PricingBLL.getPricingById(editPricingDetailsModel.PricingId).DomainId;
            }

            return View(editPricingDetailsModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPricingContent(EditPricingDetailsModel model)
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
                PricingDetailsBLL.SavePricingDetails(model);

                PricingDetailsModel pricingDetailsModel = new PricingDetailsModel();
                pricingDetailsModel.pricingdetailsList = PricingDetailsBLL.Getpricingdetailslist(model.PricingId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManagePricingContent, model.PricingId));
                return View("ManagePricingContent", pricingDetailsModel);
                
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeletePricingContent(Int64 pricingDetailsId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditPricingDetailsModel model = new EditPricingDetailsModel();
            if (pricingDetailsId > 0)
            {
                model = PricingDetailsBLL.getPricingDetailsById(pricingDetailsId);
            }
            if (PricingDetailsBLL.DeletePricingContent(pricingDetailsId))
            {

                PricingDetailsModel pricingDetailsModel = new PricingDetailsModel();
                pricingDetailsModel.pricingdetailsList = PricingDetailsBLL.Getpricingdetailslist(model.PricingId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManagePricingContent, model.PricingId));
                return View("ManagePricingContent", pricingDetailsModel);
            }
            return View("ManagePricingContent");

        }

    }
}
