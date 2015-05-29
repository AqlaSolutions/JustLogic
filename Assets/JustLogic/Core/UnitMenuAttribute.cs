using System;

namespace JustLogic.Core
{
    /// <summary>
    /// Specifies menu where the unit should be shown; use multiple attribute instances to specify multiple menu items
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class UnitMenuAttribute : Attribute
    {

        public UnitMenuAttribute(string menu)
        {
            if (menu == null) throw new ArgumentNullException("menu");
            Menu = menu;
        }

        public string Menu { get; private set; }

    }
}