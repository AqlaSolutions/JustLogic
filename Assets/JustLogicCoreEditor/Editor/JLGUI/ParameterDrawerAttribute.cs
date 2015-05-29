using System;

namespace JustLogic.Editor.JLGUI
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class ParameterDrawerAttribute : Attribute
    {
        public ParameterDrawerAttribute(Type supportedType)
        {
            SupportedType = supportedType;
        }

        public Type SupportedType { get; private set; }
        public int Order { get; set; }
    }

}