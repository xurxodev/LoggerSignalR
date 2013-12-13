using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggerSignalR.Web.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index(string q)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            logger.Info("Begin Search");

            logger.Info("Search results for " + q);

            ViewBag.SearchText = q;

            logger.Info("End Search");

            return View();
        }
	}
}