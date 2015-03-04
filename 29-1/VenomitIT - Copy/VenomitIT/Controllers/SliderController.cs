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
    public class SliderController : Controller
    {
        //
        // GET: /Slider/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageSlider(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            SliderModel model = new SliderModel();
            if (domainId > 0)
            {

                model.sliderList = SliderBLL.Getsliderlist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }
        public ActionResult AddSlider(Int64 domainId)
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
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditSlider", model);
        }
        [HttpPost]
        public ActionResult AddSlider(EditSliderModel model, HttpPostedFileBase file)
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
            string physicalPath = HttpContext.Server.MapPath("/") + "SliderImages" + "\\";
            string fullpath = physicalPath + System.IO.Path.GetFileName(Request.Files[0].FileName);
            if (path != null && path != "")
            {
                model.ImagePath = "/SliderImages/" + System.IO.Path.GetFileName(Request.Files[0].FileName);
            }
            else
            {
                ModelState.AddModelError("ImagePath", "please select image");
            }
            if (ModelState.IsValid)
            {
                SliderBLL.SaveSliderDetails(model);
                if (path != null && path != "")
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {

                        Request.Files[0].SaveAs(physicalPath + System.IO.Path.GetFileName(Request.Files[i].FileName));

                    }
                }

                SliderModel sliderModel = new SliderModel();
                sliderModel.sliderList = SliderBLL.Getsliderlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageSlider, model.DomainId));
                return View("ManageSlider", model);
            }
            else
            {
                return View("EditSlider", model);
            }

        }
        public ActionResult EditSlider(Int64 sliderId)
        {
            EditSliderModel editSliderModel = new EditSliderModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (sliderId > 0)
            {
                ViewBag.msg = "Edit Domain";
                editSliderModel = SliderBLL.getSliderById(sliderId);
            }

            return View(editSliderModel);
        }
        [HttpPost]
        public ActionResult EditSlider(EditSliderModel model, HttpPostedFileBase file)
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
                string physicalPath = HttpContext.Server.MapPath("/") + "SliderImages" + "\\";
                string fullpath = physicalPath + System.IO.Path.GetFileName(Request.Files[0].FileName);
                if (path != null && path != "")
                {
                    model.ImagePath = "/SliderImages/" + System.IO.Path.GetFileName(Request.Files[0].FileName);
                }
                else
                {
                    ModelState.AddModelError("ImagePath", "please select image");
                }
                SliderBLL.SaveSliderDetails(model);
                if (path != null && path != "")
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {

                        Request.Files[0].SaveAs(physicalPath + System.IO.Path.GetFileName(Request.Files[i].FileName));

                    }
                }
                SliderModel sliderModel = new SliderModel();
                sliderModel.sliderList = SliderBLL.Getsliderlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageSlider, model.DomainId));
                return View("ManageSlider", sliderModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteSlider(Int64 sliderId)
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
            if (sliderId > 0)
            {
                model = SliderBLL.getSliderById(sliderId);
            }
            if (SliderBLL.DeleteSlider(sliderId))
            {
                SliderModel sliderModel = new SliderModel();
                sliderModel.sliderList = SliderBLL.Getsliderlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageSlider, model.DomainId));
                return View("ManageSlider", sliderModel);
            }
            return View("ManageSlider");

        }



        //Manage Slider Content
        public ActionResult ManageSliderContent(Int64 sliderId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            SliderContentModel model = new SliderContentModel();
            if (sliderId > 0)
            {

                model.slidercontentList = SliderContentBLL.Getslidercontentlist(sliderId).ToList();
                model.SliderId = sliderId;
                model.DomainId = SliderBLL.getSliderById(sliderId).DomainId;
            }

            return View(model);
        }
        public ActionResult AddSliderContent(Int64 sliderId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditSliderContentModel model = new EditSliderContentModel();
            if (sliderId > 0)
            {
                model.SliderId = sliderId;
                model.DomainId = SliderBLL.getSliderById(sliderId).DomainId;
            }
            return View("EditSliderContent", model);
        }
        [HttpPost]
        public ActionResult AddSliderContent(EditSliderContentModel model, HttpPostedFileBase file)
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
                SliderContentBLL.SaveSlidercontentDetails(model);

                SliderContentModel sliderContentModel = new SliderContentModel();
                sliderContentModel.slidercontentList = SliderContentBLL.Getslidercontentlist(model.SliderId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageSliderContent, model.SliderId));
                return View("ManageSliderContent", sliderContentModel);
            }
            else
            {
                return View("EditSliderContent", model);
            }

        }

        public ActionResult EditSliderContent(Int64 sliderDetailsId)
        {
            EditSliderContentModel editSliderContentModel = new EditSliderContentModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (sliderDetailsId > 0)
            {
                ViewBag.msg = "Edit Slider Content";
                editSliderContentModel = SliderContentBLL.getSliderDetailsById(sliderDetailsId);
                editSliderContentModel.DomainId = SliderBLL.getSliderById(editSliderContentModel.SliderId).DomainId;
            }

            return View(editSliderContentModel);
        }
        [HttpPost]
        public ActionResult EditSliderContent(EditSliderContentModel model)
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

                SliderContentBLL.SaveSlidercontentDetails(model);
                SliderContentModel sliderContentModel = new SliderContentModel();
                sliderContentModel.slidercontentList = SliderContentBLL.Getslidercontentlist(model.SliderId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageSliderContent, model.SliderId));
                return View("ManageSliderContent", sliderContentModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteSliderContent(Int64 sliderDetailsId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditSliderContentModel model = new EditSliderContentModel();
            if (sliderDetailsId > 0)
            {
                model = SliderContentBLL.getSliderDetailsById(sliderDetailsId);
            }
            if (SliderContentBLL.DeleteSliderContent(sliderDetailsId))
            {
                SliderContentModel sliderContentModel = new SliderContentModel();
                sliderContentModel.slidercontentList = SliderContentBLL.Getslidercontentlist(model.SliderId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageSliderContent, model.SliderId));
                return View("ManageSliderContent", sliderContentModel);
            }
            return View("ManageSliderContent");

        }

    }
}
