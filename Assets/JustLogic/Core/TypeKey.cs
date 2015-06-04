using System;

namespace JustLogic.Core
{
    /// <summary>
    /// For hashtables, supports aliases
    /// </summary>
    public class TypeKey
    {
        public Type Type { get; private set; }
        public TypeInfo InternalType { get { return _internalType; } }

        TypeKey(Type type)
        {
            Type = type;
            _internalType = GetMainAlias(type);
            _hashCode = _internalType.GetHashCode();
        }

        public static Type GetMainAlias(Type type)
        {
            if ((type == typeof(long))
              || (type == typeof(ulong))
              || (type == typeof(short))
              || (type == typeof(ushort))
              || (type == typeof(byte))
              || (type == typeof(sbyte)))
                return typeof(int);
            else if ((type == typeof(decimal))
                     || (type == typeof(double)))
                return typeof(float);
            else
                return type;
        }

        public static implicit operator TypeKey(Type type)
        {
            return new TypeKey(type);
        }

        public static implicit operator Type(TypeKey type)
        {
            return type.Type;
        }

        readonly TypeInfo _internalType;
        readonly int _hashCode;

        public override int GetHashCode()
        {
            return _hashCode;
        }

        public override bool Equals(object obj)
        {
            Type t;
            var tk = obj as TypeKey;
            if (tk != null)
                t = tk.InternalType;
            else
            {
                t = obj as Type;
                if (t == null) return false;
                t = GetMainAlias(t);
            }
            return _internalType == t;
        }
    }
}