using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace JustLogic.Core
{
    public static class Library
    {
        private static IList<TypeInfo> _expressions;
        private static IList<TypeInfo> _actions;
        private static IList<TypeInfo> _unityObjects;
        private static IList<TypeInfo> _allNotAbstract;
        private static IList<TypeInfo> _all;
        private static IList<IEventDescription> _events;

        public static IList<TypeInfo> Expressions { get { Initialize(true); return _expressions; } }
        public static IList<TypeInfo> Actions { get { Initialize(true); return _actions; } }
        public static IList<TypeInfo> UnityObjects { get { Initialize(true); return _unityObjects; } }
        public static IList<TypeInfo> AllNotAbstract { get { Initialize(true); return _allNotAbstract; } }
        public static IList<TypeInfo> All { get { Initialize(true); return _all; } }

        public static IList<IEventDescription> Events { get { Initialize(true); return _events; } }

        public static Instantiator Instantiator { get; private set; }

        //public static IList<TypeInfo> Enums { get { Initialize(true); return _enums; } }

        private static volatile bool _initialized;
        private static readonly object LoadingLock = new object();
        public static bool Initialized { get { return _initialized; } private set { _initialized = value; } }

        static Library()
        {
            if (Application.isPlaying)
                Initialize(true);
        }

        public static void BeginInitialize()
        {
            ThreadPool.QueueUserWorkItem(w => Initialize());
        }

        public static void Initialize(bool waitInitialization = false)
        {
            if (_initialized) return;
            if (!Monitor.TryEnter(LoadingLock))
            {
                if (waitInitialization)
                {
                    Monitor.Enter(LoadingLock);
                    if (_initialized)
                    {
                        Monitor.Exit(LoadingLock);
                        return;
                    }
#if LOG
                    Debug.Log("Waiting for lock, " + Environment.StackTrace);
#endif
                }
                else return;
            }
            try
            {
                if (_initialized) return;

                MethodInfo getReferencedMethod = typeof(Assembly).GetMethod("GetReferencedAssemblies", Type.EmptyTypes);

                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (getReferencedMethod != null)
                        foreach (AssemblyName asm in (AssemblyName[])getReferencedMethod.Invoke(assembly, null))
                            try
                            {
                                Assembly.Load(asm);
                            }
                            catch { }

                    var inst = assembly.GetType("JustLogic.Core.ConcreteInstantiator");
                    if (inst != null)
                        Instantiator = (Instantiator)Activator.CreateInstance(inst);
                }

                if (Instantiator == null)
                    throw new InvalidOperationException("Can't find JustLogic.Core.ConcreteInstantiator");

                var expressions = new List<TypeInfo>();
                var actions = new List<TypeInfo>();
                var unityObjects = new List<TypeInfo>();
                var allNotAbstract = new List<TypeInfo>();
                var all = new List<TypeInfo>();
                //var enums = new List<TypeInfo>();
                var events = new List<IEventDescription>();

                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type t in assembly.GetExportedTypes())
                    {
                        TypeInfo type = t;
                        all.Add(type);
                        AllByFullName[type.Type.FullName] = type;
                        if (t.IsAbstract) continue;
                        allNotAbstract.Add(type);
                        if (t.IsSubclassOf(typeof(UnityEngine.Object)))
                            unityObjects.Add(type);
                        if (t.IsSubclassOf(typeof(JLExpression)))
                            expressions.Add(type);
                        if (t.IsSubclassOf(typeof(JLAction)))
                            actions.Add(type);

                        if (t.IsValueType && typeof(IEventDescription).IsAssignableFrom(t))
                            events.Add((IEventDescription)Activator.CreateInstance(t));
                    }
                }
                _expressions = new ReadOnlyCollection<TypeInfo>(expressions);
                _actions = new ReadOnlyCollection<TypeInfo>(actions);
                _unityObjects = new ReadOnlyCollection<TypeInfo>(unityObjects);
                _unityObjects = new ReadOnlyCollection<TypeInfo>(allNotAbstract);
                _allNotAbstract = new ReadOnlyCollection<TypeInfo>(expressions);
                _all = new ReadOnlyCollection<TypeInfo>(all);
                _events = new ReadOnlyCollection<IEventDescription>(events);
                _initialized = true;
                Thread.MemoryBarrier();
                Type editorClass;
                if ((editorClass = FindType("JustLogic.Editor.DrawersLibrary")) != null)
                {
                    var m = editorClass.GetMethod("ForceInitialize", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    if (m != null)
                        m.Invoke(null, new object[0]);
                }
            }
            finally { Monitor.Exit(LoadingLock); }
        }

        static readonly Dictionary<Type, ReadOnlyCollection<TypeInfo>> Lists = new Dictionary<Type, ReadOnlyCollection<TypeInfo>>();
        static readonly Dictionary<Type, ReadOnlyCollection<TypeInfo>> ListsNotAbstract = new Dictionary<Type, ReadOnlyCollection<TypeInfo>>();

        public static IList<TypeInfo> ListOfType(Type type, bool allowAbstract = false)
        {
            Initialize(true);
            var cache = allowAbstract ? Lists : ListsNotAbstract;

            ReadOnlyCollection<TypeInfo> result;
            if (cache.TryGetValue(type, out result))
                return result;

            var lst = new List<TypeInfo>();
            var listToLookup = All;
            if (!allowAbstract)
            {
                listToLookup = AllNotAbstract;
                if (typeof(JLExpression).IsAssignableFrom(type))
                    listToLookup = Expressions;
                else if (typeof(JLAction).IsAssignableFrom(type))
                    listToLookup = Actions;
                else if (typeof(UnityEngine.Object).IsAssignableFrom(type))
                    listToLookup = UnityObjects;
            }
            for (int i = 0; i < listToLookup.Count; i++)
            {
                var typeInfo = listToLookup[i];
                if (typeInfo.Type == type ||
                    (((typeInfo.UnitUsage == null) || !typeInfo.UnitUsage.StrictApplicability) && type.IsAssignableFrom(typeInfo.Type)))
                {
                    lst.Add(typeInfo);
                }
            }
            result = new ReadOnlyCollection<TypeInfo>(lst);
            cache.Add(type, result);
            return result;
        }

        static readonly Dictionary<string, TypeInfo> AllByFullName = new Dictionary<string, TypeInfo>();

        public static TypeInfo FindType(string fullName)
        {
            Initialize(true);
            TypeInfo t;
            AllByFullName.TryGetValue(fullName, out t);
            return t;
        }

        static readonly Dictionary<TypeKey, ReadOnlyCollection<TypeInfo>> ExpressionsByReturnType = new Dictionary<TypeKey, ReadOnlyCollection<TypeInfo>>();

        public static IList<TypeInfo> ListExpressionsForExpectedType(Type type)
        {
            Initialize(true);
            if ((type == null) || (type == typeof(object)))
                return Expressions;
            TypeKey key = type;

            ReadOnlyCollection<TypeInfo> result;
            if (ExpressionsByReturnType.TryGetValue(key, out result))
                return result;

            TypeInfo internalType = key.InternalType;

            var lst = new List<TypeInfo>();
            foreach (var typeInfo in Expressions)
            {
                if (typeInfo.IsExpressionResultAssignableTo(internalType))
                {
                    lst.Add(typeInfo);
                }
            }
            result = new ReadOnlyCollection<TypeInfo>(lst.ToArray());

            ExpressionsByReturnType.Add(key, result);
            return result;
        }
    }

    public static class EnumerableExtensions
    {

        public static T[] ToArray2<T>(this IEnumerable<T> enumerable)
        {
            var lst = new List<T>();
            foreach (var el in enumerable)
            {
                lst.Add(el);
            }
            return lst.ToArray();
        }
    }
}