using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XandaPOS.Controllers
{
    public class MasterdataController : Controller
    {
        // GET: Masterdata
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanyMaster()
        {
            return View();
        }
        public ActionResult CustomerMaster()
        {
            return View();
        }
    }
}