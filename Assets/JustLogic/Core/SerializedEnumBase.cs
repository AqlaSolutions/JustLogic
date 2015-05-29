using System;

namespace JustLogic.Core
{
    /// <tocexclude />
    [Serializable]
    public abstract class SerializedEnumBase
    {
        public int Value;
        public string TypeFullName;
        Type _cachedType;
        public Type RuntimeType { get { return _cachedType ?? (_cachedType = Library.FindType(TypeFullName)); } }
    }
}