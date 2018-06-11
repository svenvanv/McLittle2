using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McLittle.Areas.CMS.Controllers
{
    public class CMSController : Controller
    {
        // GET: CMS/CMS
        public ActionResult Index()
        {
            return View();
        }
    }
}