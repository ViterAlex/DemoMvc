using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMvcApp.Controllers
{
    public class DateCalcController : Controller
    {
        // GET: DateCalc
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Difference()
        {
            var from = Request.Form["from"].ToString();
            var to = Request.Form["to"].ToString();
            try
            {
                return PartialView(DateTime.Parse(to) - DateTime.Parse(from));
            }
            catch (Exception)
            {
                return PartialView(TimeSpan.Zero);
            }
        }
    }
}