using Restaurante.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Events
{
    public class DisparadorEventos
    {
        private Dictionary<Type, Action<object>> commandHandlers =
            new Dictionary<Type, Action<object>>();
        private Dictionary<Type, List<Action<object>>> eventSubscribers =
            new Dictionary<Type, List<Action<object>>>();
        private IEventStore eventStore;
    }
}
