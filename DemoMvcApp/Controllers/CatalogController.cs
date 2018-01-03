using DemoMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMvcApp.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            CatalogModel.DirectoryPath = Request.Form["path"];
            return View();
        }


        public ActionResult GetCatalog(string file)
        {
            return PartialView(CatalogModel.GetFiles());
        }
    }
}