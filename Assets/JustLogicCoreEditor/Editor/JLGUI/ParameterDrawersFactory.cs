using System;
using JustLogic.Core;
using JustLogic.Editor.JLGUI.Drawers;
using UnityEngine;

namespace JustLogic.Editor.JLGUI
{
    public class ParameterDrawersFactory : IParameterDrawersFactory
    {
        public static readonly IParameterDrawersFactory Default = new ParameterDrawersFactory();

        static IParameterDrawer TryDrawer(Type drawer, DrawerInitArgs args, object value, IDrawContext context)
        {
            var drawerInstance = Activator.CreateInstance(drawer) as IParameterDrawer;
            if (drawerInstance != null)
            {
                if (drawerInstance.Initialize(args, value, context)) return drawerInstance;
                drawerInstance.Dispose();
                return null;
            }
            return null;
        }

        public IParameterDrawer CreateDrawer(DrawerInitArgs arguments, object value, IDrawContext context)
        {
            if ((arguments.ParameterInfo != null) && (arguments.ParameterInfo.Drawer != null) && (!arguments.SupportedType.Type.IsArray))
            {
                var d = TryDrawer(arguments.ParameterInfo.Drawer, arguments, value, context);
                if (d != null) return d;
            }
            using (var list = DrawersLibrary.Get(arguments.SupportedType))
                while (list.MoveNext())
                {
                    var d = TryDrawer(list.Current, arguments, value, context);
                    if (d != null) return d;
                }
            var def = new DefaultDrawer();
            if (def.Initialize(arguments, value, context)) return def;
            return null;
        }

        public bool HasDrawers(Type supportedType)
        {
            return DrawersLibrary.Get(supportedType).MoveNext();
        }
    }
}