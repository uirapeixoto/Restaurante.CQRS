using Restaurante.UI.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.UI.Controllers
{
    [IncludeLayoutData]
    public class GarcomController : Controller
    {
        // GET: Garcom
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tarefa()
        {
            return View();
        }
    }
}