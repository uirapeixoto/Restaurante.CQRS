using Restaurante.Command.Mesas.Handler;
using Restaurante.Infra.Context;
using Restaurante.IOC;
using Restaurante.Query.Handler;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Restaurante.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //Registrando o contexto
            container.Register<ICafeContext, CafeContext>(Lifestyle.Scoped);

            //Registrando as query Handlers
            typeof(MesaAbertaQueryHandler).Assembly.GetExportedTypes()
                .Where(x => x.Namespace.EndsWith("Handler"))
                .Where(x => x.GetInterfaces().Any())
                .ToList()
                .ForEach(x => container.Register(x.GetInterfaces().Single(), x, Lifestyle.Transient));

            typeof(AbrirMesaCommandHandler).Assembly.GetExportedTypes()
                .Where(x => x.Namespace.EndsWith("Handler"))
                .Where(x => x.GetInterfaces().Any())
                .ToList()
                .ForEach(x => container.Register(x.GetInterfaces().Single(), x, Lifestyle.Transient));

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
