using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VenomitIT.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LeftNav(string DomainId)
        {
            if (!string.IsNullOrEmpty(DomainId))
            {
               // Int64 domainId = Convert.ToInt64(DomainId);
                ViewBag.domainId = DomainId;
                return PartialView("LeftNav");
            }
            return PartialView();
        }

    }
}
