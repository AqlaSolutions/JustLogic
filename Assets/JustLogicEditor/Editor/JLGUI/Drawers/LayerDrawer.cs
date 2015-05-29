using UnityEditor;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class LayerDrawer : AutoHorizontalLayoutedDrawer
    {
        protected override bool OnDraw(IDrawContext context)
        {
            var value = (int)Value;
            context.BeginLook(true);
            try
            {
                int newValue = EditorGUILayout.LayerField(value);
                if (!newValue.Equals(value))
                {
                    Value = newValue;
                    return true;
                }
                return false;
            }
            finally { context.EndLook(); }
        }
    }
}