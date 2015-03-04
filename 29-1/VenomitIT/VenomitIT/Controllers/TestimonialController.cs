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
    public class TestimonialController : Controller
    {
        //
        // GET: /Testimonial/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageTestimonial(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            TestimonailModel model = new TestimonailModel();
            if (domainId > 0)
            {

                model.testimonialList = TestimonailBLL.Gettestimoniallist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }

        public ActionResult AddTestimonial(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditTestimonailModel model = new EditTestimonailModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditTestimonial", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTestimonial(EditTestimonailModel model)
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
                TestimonailBLL.SaveTestimonialDetails(model);
                TestimonailModel testimonailModel = new TestimonailModel();
                testimonailModel.testimonialList = TestimonailBLL.Gettestimoniallist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageTestimonial, model.DomainId));
                return View("ManageTestimonial", testimonailModel);
            }
            else
            {
                return View("EditTestimonial", model);
            }

        }

        public ActionResult EditTestimonial(Int64 testimonialId)
        {
            EditTestimonailModel editTestimonailModel = new EditTestimonailModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (testimonialId > 0)
            {
                ViewBag.msg = "Edit Testimonial";
                editTestimonailModel = TestimonailBLL.gettestimonialById(testimonialId);
            }

            return View(editTestimonailModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTestimonial(EditTestimonailModel model)
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

                TestimonailBLL.SaveTestimonialDetails(model);
                TestimonailModel testimonailModel = new TestimonailModel();
                testimonailModel.testimonialList = TestimonailBLL.Gettestimoniallist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageTestimonial, model.DomainId));
                return View("ManageTestimonial", testimonailModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteTestimonial(Int64 testimonialId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditTestimonailModel model = new EditTestimonailModel();
            if (testimonialId > 0)
            {
                model = TestimonailBLL.gettestimonialById(testimonialId);
            }
            if (TestimonailBLL.DeleteTestimonial(testimonialId))
            {
                TestimonailModel testimonailModel = new TestimonailModel();
                testimonailModel.testimonialList = TestimonailBLL.Gettestimoniallist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageTestimonial, model.DomainId));
                return View("ManageTestimonial", testimonailModel);
            }
            return View("ManageTestimonial");

        }


        //Customer Testimonail Details

        public ActionResult ManageCustomerTestimonial(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            CustomerTestimonialModel model = new CustomerTestimonialModel();
            if (domainId > 0)
            {

                model.custometestimonailList = CustomerTestimonialBLL.GetCustomertestimoniallist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }

        public ActionResult AddCustomerTestimonial(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditCustomerTestimonialModel model = new EditCustomerTestimonialModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditCustomerTestimonial", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCustomerTestimonial(EditCustomerTestimonialModel model, HttpPostedFileBase file)
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
            string physicalPath = HttpContext.Server.MapPath("/") + "CustomerImages" + "\\";
            string fullpath = physicalPath + System.IO.Path.GetFileName(Request.Files[0].FileName);
            if (path != null && path != "")
            {
                model.ImagePath = "/CustomerImages/" + System.IO.Path.GetFileName(Request.Files[0].FileName);
            }
            else
            {
                ModelState.AddModelError("ImagePath", "please select image");
            }
            if (ModelState.IsValid)
            {
                
                CustomerTestimonialBLL.SaveCustomertestimonialDetails(model);
                if (path != null && path != "")
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {

                        Request.Files[0].SaveAs(physicalPath + System.IO.Path.GetFileName(Request.Files[i].FileName));

                    }
                }
                CustomerTestimonialModel customerTestimonialModel = new CustomerTestimonialModel();
                customerTestimonialModel.custometestimonailList = CustomerTestimonialBLL.GetCustomertestimoniallist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageCustomerTestimonial, model.DomainId));
                return View("ManageCustomerTestimonial", model);
            }
            else
            {
                return View("EditCustomerTestimonial", model);
            }

        }


        public ActionResult EditCustomerTestimonial(Int64 customerId)
        {
            EditCustomerTestimonialModel editCustomerTestimonialModel = new EditCustomerTestimonialModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (customerId > 0)
            {
                ViewBag.msg = "Edit Customer Testimonail";
                editCustomerTestimonialModel = CustomerTestimonialBLL.getCustomerTestimonialById(customerId);
            }

            return View(editCustomerTestimonialModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditCustomerTestimonial(EditCustomerTestimonialModel model, HttpPostedFileBase file)
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
                string physicalPath = HttpContext.Server.MapPath("/") + "CustomerImages" + "\\";
                string fullpath = physicalPath + System.IO.Path.GetFileName(Request.Files[0].FileName);
                if (path != null && path != "")
                {
                    model.ImagePath = "/CustomerImages/" + System.IO.Path.GetFileName(Request.Files[0].FileName);
                }              
                CustomerTestimonialBLL.SaveCustomertestimonialDetails(model);
                if (path != null && path != "")
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {

                        Request.Files[0].SaveAs(physicalPath + System.IO.Path.GetFileName(Request.Files[i].FileName));

                    }
                }
                CustomerTestimonialModel customerTestimonialModel = new CustomerTestimonialModel();
                customerTestimonialModel.custometestimonailList = CustomerTestimonialBLL.GetCustomertestimoniallist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageCustomerTestimonial, model.DomainId));
                return View("ManageCustomerTestimonial", model);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteCustomerTestimonial(Int64 customerId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditCustomerTestimonialModel model = new EditCustomerTestimonialModel();
            if (customerId > 0)
            {
                model = CustomerTestimonialBLL.getCustomerTestimonialById(customerId);
            }
            if (CustomerTestimonialBLL.DeleteCustomerTestimonial(customerId))
            {               
                CustomerTestimonialModel customerTestimonialModel = new CustomerTestimonialModel();
                customerTestimonialModel.custometestimonailList = CustomerTestimonialBLL.GetCustomertestimoniallist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageCustomerTestimonial, model.DomainId));
                return View("ManageCustomerTestimonial", model);
            }
            return View("ManageCustomerTestimonial");

        }

    }
}
