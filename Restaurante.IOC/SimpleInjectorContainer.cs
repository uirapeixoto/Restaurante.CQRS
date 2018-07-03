using Restaurante.Infra.Context;
using SimpleInjector;

namespace Restaurante.IOC
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            //Registrando as implementações
            container.Register<ICafeContext, CafeContext>();
            container.Verify();
            return container;
        }
    }
}
