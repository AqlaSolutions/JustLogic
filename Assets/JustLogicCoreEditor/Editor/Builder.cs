using JustLogic.Core;

namespace JustLogic.Editor
{
    public static class Builder
    {
        public static T BuildA<T>(System.Action<T> initializer = null) where T : JLAction
        {
            var r = JLScriptableHelper.CreateNew<T>();
            if (initializer != null)
                initializer(r);
            return r;
        }

        public static T BuildE<T>(System.Action<T> initializer = null) where T : JLExpression
        {
            var r = JLScriptableHelper.CreateNew<T>();
            if (initializer != null)
                initializer(r);
            return r;
        }
    }
}