using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;

namespace Restaurante.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/acesso/login")
            });
        }
    }
}