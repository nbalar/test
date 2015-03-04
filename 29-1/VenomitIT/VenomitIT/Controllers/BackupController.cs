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
    public class BackupController : Controller
    {
        //
        // GET: /Backup/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageBackup(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            BackupModel model = new BackupModel();
            if (domainId > 0)
            {

                model.backupList = BackupBLL.Getbackuplist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }
        public ActionResult AddBackup(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditBackupModel model = new EditBackupModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditBackup", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBackup(EditBackupModel model, HttpPostedFileBase file)
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
            string physicalPath = HttpContext.Server.MapPath("/") + "BackupImage" + "\\";
            string fullpath = physicalPath + System.IO.Path.GetFileName(Request.Files[0].FileName);
            if (path != null && path != "")
            {
                model.BackupImage = "/BackupImage/" + System.IO.Path.GetFileName(Request.Files[0].FileName);
            }
            else
            {
                ModelState.AddModelError("BackupImage", "please select image");
            }
            if (ModelState.IsValid)
            {

                BackupBLL.SaveBackupDetails(model);
                if (path != null && path != "")
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {

                        Request.Files[0].SaveAs(physicalPath + System.IO.Path.GetFileName(Request.Files[i].FileName));

                    }
                }
                BackupModel backupModel = new BackupModel();
                backupModel.backupList = BackupBLL.Getbackuplist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageBackup, model.DomainId));
                return View("ManageBackup", model);
            }
            else
            {
                return View("EditBackup", model);
            }

        }


        public ActionResult EditBackup(Int64 backupId)
        {
            EditBackupModel editBackupModel = new EditBackupModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (backupId > 0)
            {
                ViewBag.msg = "Edit Backup Details";
                editBackupModel = BackupBLL.getBackupById(backupId);
            }

            return View(editBackupModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBackup(EditBackupModel model, HttpPostedFileBase file)
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
                string physicalPath = HttpContext.Server.MapPath("/") + "BackupImage" + "\\";
                string fullpath = physicalPath + System.IO.Path.GetFileName(Request.Files[0].FileName);
                if (path != null && path != "")
                {
                    model.BackupImage = "/BackupImage/" + System.IO.Path.GetFileName(Request.Files[0].FileName);
                }
                BackupBLL.SaveBackupDetails(model);
                if (path != null && path != "")
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {

                        Request.Files[0].SaveAs(physicalPath + System.IO.Path.GetFileName(Request.Files[i].FileName));

                    }
                }
                BackupModel backupModel = new BackupModel();
                backupModel.backupList = BackupBLL.Getbackuplist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageBackup, model.DomainId));
                return View("ManageBackup", model);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteBackup(Int64 backupId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditBackupModel model = new EditBackupModel();
            if (backupId > 0)
            {
                model = BackupBLL.getBackupById(backupId);
            }
            if (BackupBLL.DeleteBackupDetails(backupId))
            {
                BackupModel backupModel = new BackupModel();
                backupModel.backupList = BackupBLL.Getbackuplist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageBackup, model.DomainId));
                return View("ManageBackup", model);
            }
            return View("ManageBackup");

        }
    }
}
