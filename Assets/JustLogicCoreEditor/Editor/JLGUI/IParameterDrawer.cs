using System;
using UnityEngine;

namespace JustLogic.Editor.JLGUI
{
    public interface IParameterDrawer : IDisposable
    {
        object Value { get; }
        ParameterDrawerLayout Layout { get; }

        ParameterDrawerLayout SelfLayout { get; }

        /// <summary>
        /// Returns true if drawer is suitable for specified args
        /// </summary>
        bool Initialize(DrawerInitArgs args, object value, IDrawContext context);

        /// <summary>
        /// Can set Layout and other properties
        /// </summary>
        void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple);

        /// <summary>
        /// Invoke from OnGUI
        /// </summary>
        /// <returns>Is Value changed</returns>
        bool Draw(IDrawContext context);
    }

    public static class DrawersExtensions
    {
        public static bool SimpleDraw(this IParameterDrawer drawer, IDrawContext context, int parentsFromHorizontal = 0)
        {
            if (drawer == null) return false;
            int dummy;
            bool isTuple;
            drawer.UpdateLayoutType(0, context, out dummy, out dummy, out isTuple);
            return drawer.Draw(context);

        }
    }
}