using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.UI.Controllers
{
    [AllowAnonymous]
    public class AcessoController : Controller
    {
        // GET: Acesso
        public ActionResult Login()
        {
            return View();
        }
    }
}