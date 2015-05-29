using System;

namespace JustLogic.Editor.JLGUI
{
    public interface IParameterDrawersFactory
    {
        /// <summary>
        /// Invokes Initialize and Dispose
        /// </summary>
        IParameterDrawer CreateDrawer(DrawerInitArgs arguments, object value, IDrawContext context);

        bool HasDrawers(Type supportedType);
    }
}