namespace JustLogic.Editor.JLGUI
{
    public enum ParameterDrawerLayout
    {
        VerticalRoot = 0,
        VerticalNested,
        Horizontal,
        HorizontalLimited
    }

    public static class ParameterDrawerLayoutExtensions
    {
        public static bool IsHorizontal(this ParameterDrawerLayout layout)
        {
            return layout == ParameterDrawerLayout.Horizontal || layout == ParameterDrawerLayout.HorizontalLimited;
        }

        public static bool IsVertical(this ParameterDrawerLayout layout)
        {
            return !IsHorizontal(layout);
        }
    }
}