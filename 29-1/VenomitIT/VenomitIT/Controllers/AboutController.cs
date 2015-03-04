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
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageAbout(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            AboutUsModel model = new AboutUsModel();
            if (domainId > 0)
            {

                model.aboutList = AboutUsBLL.Getaboutlist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }
        public ActionResult AddAbout(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditAboutUsModel model = new EditAboutUsModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditAbout", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAbout(EditAboutUsModel model)
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
                AboutUsBLL.SaveAboutusDetails(model);
                AboutUsModel aboutusModel = new AboutUsModel();
                aboutusModel.aboutList = AboutUsBLL.Getaboutlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageAbout, model.DomainId));
                return View("ManageAbout", aboutusModel);
            }
            else
            {
                return View("EditAbout", model);
            }

        }

        public ActionResult EditAbout(Int64 aboutId)
        {
            EditAboutUsModel editAboutUsModel = new EditAboutUsModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (aboutId > 0)
            {
                ViewBag.msg = "Edit AboutUs";
                editAboutUsModel = AboutUsBLL.getAboutusById(aboutId);
            }

            return View(editAboutUsModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditAbout(EditAboutUsModel model, HttpPostedFileBase file)
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

                AboutUsBLL.SaveAboutusDetails(model);
                AboutUsModel aboutusModel = new AboutUsModel();
                aboutusModel.aboutList = AboutUsBLL.Getaboutlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageAbout, model.DomainId));
                return View("ManageAbout", aboutusModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteAbout(Int64 aboutId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditSliderModel model = new EditSliderModel();
            if (aboutId > 0)
            {
                model = SliderBLL.getSliderById(aboutId);
            }
            if (AboutUsBLL.DeleteAboutus(aboutId))
            {
                AboutUsModel aboutusModel = new AboutUsModel();
                aboutusModel.aboutList = AboutUsBLL.Getaboutlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageAbout, model.DomainId));
                return View("ManageAbout", aboutusModel);
            }
            return View("ManageAbout");

        }



        //Mange About details
        
        public ActionResult ManageAboutContent(Int64 aboutId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            AboutDetailsModel model = new AboutDetailsModel();
            if (aboutId > 0)
            {

                model.aboutusdetailsList = AboutUsDetailBLL.Getaboutuscontentlist(aboutId).ToList();
                model.AboutId = aboutId;
                model.DomainId = AboutUsBLL.getAboutusById(aboutId).DomainId;
            }

            return View(model);
        }

        public ActionResult AddAboutContent(Int64 aboutId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditAboutDetailsModel model = new EditAboutDetailsModel();
            if (aboutId > 0)
            {
                model.AboutId = aboutId;
                model.DomainId = AboutUsBLL.getAboutusById(aboutId).DomainId;
            }
            return View("EditAboutContent", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAboutContent(EditAboutDetailsModel model, HttpPostedFileBase file)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            string path = System.IO.Path.GetFileName(Request.Files[0].FileName);
            string physicalPath = HttpContext.Server.MapPath("/") + "AboutImages" + "\\";
            string fullpath = physicalPath + System.IO.Path.GetFileName(Request.Files[0].FileName);
            if (path != null && path != "")
            {
                model.AboutImage = "/AboutImages/" + System.IO.Path.GetFileName(Request.Files[0].FileName);
            }
            else
            {
                ModelState.AddModelError("AboutImage", "please select image");
            }
            if (ModelState.IsValid)
            {
              
                AboutUsDetailBLL.SaveAboutcontentDetails(model);
                if (path != null && path != "")
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {

                        Request.Files[0].SaveAs(physicalPath + System.IO.Path.GetFileName(Request.Files[i].FileName));

                    }
                }
                AboutDetailsModel aboutDetailsModel = new AboutDetailsModel();
                aboutDetailsModel.aboutusdetailsList = AboutUsDetailBLL.Getaboutuscontentlist(model.AboutId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageAboutContent, model.AboutId));
                return View("ManageAboutContent", aboutDetailsModel);
            }
            else
            {
                return View("EditAboutContent", model);
            }

        }

        public ActionResult EditAboutContent(Int64 aboutDetailsId)
        {
            EditAboutDetailsModel editAboutDetailsModel = new EditAboutDetailsModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (aboutDetailsId > 0)
            {
                ViewBag.msg = "Edit About Content";
                editAboutDetailsModel = AboutUsDetailBLL.getaboutusDetailsById(aboutDetailsId);
                editAboutDetailsModel.DomainId = AboutUsBLL.getAboutusById(editAboutDetailsModel.AboutId).DomainId;
            }

            return View(editAboutDetailsModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditAboutContent(EditAboutDetailsModel model)
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
                string path = System.IO.Path.GetFileName(Request.Files[0].FileName);
                string physicalPath = HttpContext.Server.MapPath("/") + "AboutImages" + "\\";
                string fullpath = physicalPath + System.IO.Path.GetFileName(Request.Files[0].FileName);
                if (path != null && path != "")
                {
                    model.AboutImage = "/AboutImages/" + System.IO.Path.GetFileName(Request.Files[0].FileName);
                }
                AboutUsDetailBLL.SaveAboutcontentDetails(model);

                if (path != null && path != "")
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {

                        Request.Files[0].SaveAs(physicalPath + System.IO.Path.GetFileName(Request.Files[i].FileName));

                    }
                }
                AboutDetailsModel aboutDetailsModel = new AboutDetailsModel();
                aboutDetailsModel.aboutusdetailsList = AboutUsDetailBLL.Getaboutuscontentlist(model.AboutId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageAboutContent, model.AboutId));
                return View("ManageAboutContent", aboutDetailsModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteAboutContent(Int64 aboutDetailsId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditAboutDetailsModel model = new EditAboutDetailsModel();
            if (aboutDetailsId > 0)
            {
                model = AboutUsDetailBLL.getaboutusDetailsById(aboutDetailsId);
            }
            if (AboutUsDetailBLL.DeleteAboutusContent(aboutDetailsId))
            {
                AboutDetailsModel aboutDetailsModel = new AboutDetailsModel();
                aboutDetailsModel.aboutusdetailsList = AboutUsDetailBLL.Getaboutuscontentlist(model.AboutId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageAboutContent, model.AboutId));
                return View("ManageAboutContent", aboutDetailsModel);
            }
            return View("ManageAboutContent");

        }

    }
}
