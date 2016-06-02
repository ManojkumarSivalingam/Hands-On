using Aditi.Libraries.Web.Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AditiRichWebUI.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        #region IHomeController Members

        [ActionName( "Index" )]
        public ActionResult GetIndexContents()
        {
            return View();
        }

        #endregion
    }
}