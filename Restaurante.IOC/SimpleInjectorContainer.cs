using Restaurante.Infra.Context;
using Restaurante.Query.Handler;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Linq;
using System.Reflection;

namespace Restaurante.IOC
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //Registrando as implementações
            container.Register<ICafeContext, CafeContexold>(Lifestyle.Scoped);

            //Registrando as query Handlers
            //typeof(MesaAbertaQueryHandler).Assembly.GetExportedTypes()
            //    .Where(x => x.Namespace.EndsWith("Handler"))
            //    .Where(x => x.GetInterfaces().Any())
            //    .ToList()
            //    .ForEach(x => container.Register(x.GetInterfaces().Single(), x, Lifestyle.Transient));

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            return container;
        }
    }
}
