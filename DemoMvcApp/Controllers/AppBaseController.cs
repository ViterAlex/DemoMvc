using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DemoMvcApp.Controllers
{
    public class AppBaseController:Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            Helpers.WebUtils.SetUserLocale();
        }
    }
}