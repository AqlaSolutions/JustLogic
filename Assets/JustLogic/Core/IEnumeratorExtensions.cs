using System.Collections.Generic;

namespace JustLogic.Core
{
    public static class IEnumeratorExtensions
    {
        public static bool SafeMoveNext(this IEnumerator<YieldMode> enumerator)
        {
            if (enumerator == null) return false;
            return enumerator.MoveNext();
        }
    }
}