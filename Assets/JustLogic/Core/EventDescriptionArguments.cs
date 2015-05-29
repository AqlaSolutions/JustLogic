using System;
using System.Collections;
using System.Collections.Generic;

namespace JustLogic.Core
{
    /// <summary>
    /// A collection of event argument to be provided by the <see cref="IEventDescription.Arguments"/>
    /// </summary>
    /// <tocexclude />
    public struct EventDescriptionArguments : IList<KeyValuePair<string, Type>>
    {
        public int Count
        {
            get
            {
                if (_argumentsByName == null) return 0;
                return _argumentsByName.Count;
            }
        }

        public static readonly EventDescriptionArguments None = new EventDescriptionArguments();

        public EventDescriptionArguments(IEnumerable<KeyValuePair<string, Type>> elements)
        {
            _argumentsByName = new Dictionary<string, Type>();
            _list = new List<KeyValuePair<string, Type>>(elements);
            foreach (var kv in _list)
                _argumentsByName.Add(kv.Key, kv.Value);
        }

        readonly List<KeyValuePair<string, Type>> _list;

        readonly Dictionary<string, Type> _argumentsByName;

        public KeyValuePair<string, Type> this[int index] { get { return _list[index]; } set { throw new NotSupportedException(); } }

        public Type this[string name]
        {
            get
            {
                if (_argumentsByName == null) return null;
                Type t;
                _argumentsByName.TryGetValue(name, out t);
                return t;
            }
        }

        readonly static IEnumerable<KeyValuePair<string, Type>> EmptyList = new KeyValuePair<string, Type>[0];

        public IEnumerator<KeyValuePair<string, Type>> GetEnumerator()
        {
            if (_list == null)
                return EmptyList.GetEnumerator();
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        void ICollection<KeyValuePair<string, Type>>.Add(KeyValuePair<string, Type> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<KeyValuePair<string, Type>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<KeyValuePair<string, Type>>.Contains(KeyValuePair<string, Type> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<KeyValuePair<string, Type>>.CopyTo(KeyValuePair<string, Type>[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        bool ICollection<KeyValuePair<string, Type>>.Remove(KeyValuePair<string, Type> item)
        {
            throw new NotSupportedException();
        }

        bool ICollection<KeyValuePair<string, Type>>.IsReadOnly { get { return true; } }

        int IList<KeyValuePair<string, Type>>.IndexOf(KeyValuePair<string, Type> item)
        {
            throw new NotSupportedException();
        }

        void IList<KeyValuePair<string, Type>>.Insert(int index, KeyValuePair<string, Type> item)
        {
            throw new NotSupportedException();
        }

        void IList<KeyValuePair<string, Type>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

    }
}