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
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageContact(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            ContactModel model = new ContactModel();
            if (domainId > 0)
            {

                model.contactList = ContactBLL.Getcontactlist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }
        public ActionResult AddContact(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditContactModel model = new EditContactModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditContact", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddContact(EditContactModel model, HttpPostedFileBase file)
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

                ContactBLL.SaveContactDetails(model);

                ContactModel contactModel = new ContactModel();
                contactModel.contactList = ContactBLL.Getcontactlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageContact, model.DomainId));
                return View("ManageContact", model);
            }
            else
            {
                return View("EditContact", model);
            }

        }


        public ActionResult EditContact(Int64 contactId)
        {
            EditContactModel editContactModel = new EditContactModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (contactId > 0)
            {
                ViewBag.msg = "Edit Contact Details";
                editContactModel = ContactBLL.getContactById(contactId);
            }

            return View(editContactModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContact(EditContactModel model, HttpPostedFileBase file)
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

                ContactBLL.SaveContactDetails(model);

                ContactModel contactModel = new ContactModel();
                contactModel.contactList = ContactBLL.Getcontactlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageContact, model.DomainId));
                return View("ManageContact", model);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteContact(Int64 contactId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditContactModel model = new EditContactModel();
            if (contactId > 0)
            {
                model = ContactBLL.getContactById(contactId);
            }
            if (ContactBLL.DeleteContactDetails(contactId))
            {
                ContactModel contactModel = new ContactModel();
                contactModel.contactList = ContactBLL.Getcontactlist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageContact, model.DomainId));
                return View("ManageContact", model);
            }
            return View("ManageContact");

        }

    }
}
