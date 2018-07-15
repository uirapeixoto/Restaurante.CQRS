using System.Collections.Generic;

namespace Restaurante.UI.Helper
{
    public class EnumerableHelper
    {
        public IEnumerable<T> Add<T>(IEnumerable<T> e, T value)
        {
            foreach (var cur in e)
            {
                yield return cur;
            }
            yield return value;
        }
    }
}