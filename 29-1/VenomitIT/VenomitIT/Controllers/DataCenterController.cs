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
    public class DataCenterController : Controller
    {
        //
        // GET: /DataCenter/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageDataCenter(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            DataCenterModel model = new DataCenterModel();
            if (domainId > 0)
            {

                model.dataceneterList = DataCenterBLL.Getdatalist(domainId).ToList();
                model.DomainId = domainId;
            }

            return View(model);
        }
        public ActionResult AddDataCenter(Int64 domainId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditDataCenterModel model = new EditDataCenterModel();
            if (domainId > 0)
            {
                model.DomainId = domainId;
            }
            return View("EditDataCenter", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddDataCenter(EditDataCenterModel model)
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
                DataCenterBLL.SaveDataCeneterDetails(model);
                DataCenterModel dataCenterModel = new DataCenterModel();
                dataCenterModel.dataceneterList = DataCenterBLL.Getdatalist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageDataCenter, model.DomainId));
                return View("ManageDataCenter", dataCenterModel);
            }
            else
            {
                return View("EditDataCenter", model);
            }

        }

        public ActionResult EditDataCenter(Int64 datacenterId)
        {
            EditDataCenterModel editDataCenterModel = new EditDataCenterModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (datacenterId > 0)
            {
                ViewBag.msg = "Edit DataCenter";
                editDataCenterModel = DataCenterBLL.getDataCenterById(datacenterId);
            }

            return View(editDataCenterModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditDataCenter(EditDataCenterModel model)
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

                DataCenterBLL.SaveDataCeneterDetails(model);
                DataCenterModel dataCenterModel = new DataCenterModel();
                dataCenterModel.dataceneterList = DataCenterBLL.Getdatalist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageDataCenter, model.DomainId));
                return View("ManageDataCenter", dataCenterModel);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteDataCenter(Int64 datacenterId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditDataCenterModel model = new EditDataCenterModel();
            if (datacenterId > 0)
            {
                model = DataCenterBLL.getDataCenterById(datacenterId);
            }
            if (DataCenterBLL.DeleteDataCenter(datacenterId))
            {
                DataCenterModel dataCenterModel = new DataCenterModel();
                dataCenterModel.dataceneterList = DataCenterBLL.Getdatalist(model.DomainId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageDataCenter, model.DomainId));
                return View("ManageDataCenter", dataCenterModel);
            }
            return View("ManageDataCenter");

        }


        //Manage DataCenter Details

        public ActionResult ManageDataCenterContent(Int64 datacenterId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            DataCenterDetailsModel model = new DataCenterDetailsModel();
            if (datacenterId > 0)
            {

                model.dataceneterdetailsList = DataCenterDetailsBLL.Getdatacenterdetailslist(datacenterId).ToList();
                model.DataCenterId = datacenterId;
                model.DomainId = DataCenterBLL.getDataCenterById(datacenterId).DomainId;
            }

            return View(model);
        }

        public ActionResult AddDataCenterContent(Int64 datacenterId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditDataCenterDetailsModel model = new EditDataCenterDetailsModel();
            if (datacenterId > 0)
            {
                model.DataCenterId = datacenterId;
                model.DomainId = DataCenterBLL.getDataCenterById(datacenterId).DomainId;
            }
            return View("EditDataCenterContent", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddDataCenterContent(EditDataCenterDetailsModel model)
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
                DataCenterDetailsBLL.SaveDataCenterDetails(model);
                DataCenterDetailsModel dataCenterDetailsModel = new DataCenterDetailsModel();
                dataCenterDetailsModel.dataceneterdetailsList = DataCenterDetailsBLL.Getdatacenterdetailslist(model.DataCenterId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageDataCenterContent, model.DataCenterId));
                return View("ManageDataCenterContent", dataCenterDetailsModel);
            }
            else
            {
                return View("EditDataCenterContent", model);
            }

        }

        public ActionResult EditDataCenterContent(Int64 dataDetailId)
        {
            EditDataCenterDetailsModel editDataCenterDetailsModel = new EditDataCenterDetailsModel();
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            if (dataDetailId > 0)
            {
                ViewBag.msg = "Edit DataCenter Content";
                editDataCenterDetailsModel = DataCenterDetailsBLL.getDataCenterDetailsById(dataDetailId);
                editDataCenterDetailsModel.DomainId = DataCenterBLL.getDataCenterById(editDataCenterDetailsModel.DataCenterId).DomainId;
            }

            return View(editDataCenterDetailsModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditDataCenterContent(EditDataCenterDetailsModel model)
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
                DataCenterDetailsBLL.SaveDataCenterDetails(model);
                DataCenterDetailsModel dataCenterDetailsModel = new DataCenterDetailsModel();
                dataCenterDetailsModel.dataceneterdetailsList = DataCenterDetailsBLL.Getdatacenterdetailslist(model.DataCenterId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageDataCenterContent, model.DataCenterId));
                return View("ManageDataCenterContent", dataCenterDetailsModel);

            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DeleteDataCenterContent(Int64 dataDetailId)
        {
            if (!CookieHelper.IsLoggedInUser())
            {
                Response.Redirect(NavigationURL.HomePage);
            }

            if (!AuthenticationHelper.IsAccessAllowed(UserType.Admin))
            {
                Response.Redirect(NavigationURL.HomePage);
            }
            EditDataCenterDetailsModel model = new EditDataCenterDetailsModel();
            if (dataDetailId > 0)
            {
                model = DataCenterDetailsBLL.getDataCenterDetailsById(dataDetailId);
            }
            if (DataCenterDetailsBLL.DeleteDataCenterContent(dataDetailId))
            {

                DataCenterDetailsModel dataCenterDetailsModel = new DataCenterDetailsModel();
                dataCenterDetailsModel.dataceneterdetailsList = DataCenterDetailsBLL.Getdatacenterdetailslist(model.DataCenterId).ToList();
                Response.Redirect(String.Concat(NavigationURL.ManageDataCenterContent, model.DataCenterId));
                return View("ManageDataCenterContent", dataCenterDetailsModel);
            }
            return View("ManageDataCenterContent");

        }
    }
}
