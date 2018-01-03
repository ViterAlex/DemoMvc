using DemoMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvcApp.Helpers;
namespace DemoMvcApp.Controllers
{
    public class PtoController : Controller
    {
        // GET: Pto
        public ActionResult Index()
        {
            ViewBag.Message = "Вычисление ПТО";
            return View();
        }

        [HttpPost]
        public ActionResult Update(bool needCircle, double radius)
        {
            PtoModel.Instance.DrawCircles = needCircle;
            PtoModel.Instance.Radius = radius;
            return PartialView("GetSvg", PtoModel.Instance);
        }

        [HttpPost]
        public ActionResult AddPoint(string x, string y, string button)
        {
            var x_ = double.Parse(x, CultureInfo.InvariantCulture);
            var y_ = double.Parse(y, CultureInfo.InvariantCulture);
            PtoModel.Instance.Add(new System.Windows.Point(x_, y_), button == "right");
            return PartialView("GetSvg", PtoModel.Instance);
        }
    }
}