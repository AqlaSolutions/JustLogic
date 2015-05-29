using UnityEditor;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class LayerMaskDrawer : AutoHorizontalLayoutedDrawer
    {
        bool _changed;
        protected override bool OnDraw(IDrawContext context)
        {
            bool changed = _changed;
            _changed = false;
            var value = (int)Value;
            context.BeginLook(true);
            try
            {
                JLGUILayout.LayerMaskField(null, value,
                    v =>
                    {
                        Value = v;
                        _changed = true;
                    });
            }
            finally { context.EndLook(); }
            return changed;
        }
    }
}