using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Ray))]
    public class RayDrawer : ParameterDrawerBase
    {
        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Layout = ParameterDrawerLayout.VerticalRoot;
            return base.Initialize(args, value, context);
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            hasVerticalOutline = !isAppendedToHorizontal && label != null;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            context.BeginLook(true);
            var v = (Ray)Value;
            var prevV = v;
            v.origin = EditorGUILayout.Vector3Field("Origin", v.origin);
            v.direction = EditorGUILayout.Vector3Field("Direction", v.origin);
            context.EndLook();
            if (!prevV.Equals(v))
            {
                Value = v;
                return true;
            }
            return false;
        }
    }
}