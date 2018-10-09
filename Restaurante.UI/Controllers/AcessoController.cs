using Restaurante.UI.ViewModel;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.UI.Controllers
{
    [AllowAnonymous]
    public class AcessoController : Controller
    {
        // GET: Acesso
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Não faça isso em produção
            if(model.Login == "uirapeixoto" && model.Senha == "123" )
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "William"),
                    new Claim(ClaimTypes.Email, "williambuzatto@gmail.com"),
                    new Claim(ClaimTypes.Country, "Brasil"),
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetrRedirectUrl(model.ReturnUrl));
            }

            //Autenticação falhou
            ModelState.AddModelError("", "usuário ou senha inválidos");
            return View();
        }

        private string GetrRedirectUrl(string returnUrl)
        {
            if(string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}