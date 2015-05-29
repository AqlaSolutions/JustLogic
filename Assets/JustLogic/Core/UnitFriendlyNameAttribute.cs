using System;

namespace JustLogic.Core
{
    /// <summary>
    /// Specifies a unit friendly name that is shown as a unit title in the inspector
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class UnitFriendlyNameAttribute : Attribute
    {
        public UnitFriendlyNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}