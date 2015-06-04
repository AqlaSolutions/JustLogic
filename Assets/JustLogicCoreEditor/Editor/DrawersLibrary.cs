using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using JustLogic.Core;
using JustLogic.Editor.JLGUI;
using Debug = UnityEngine.Debug;

namespace JustLogic.Editor
{
    public static class DrawersLibrary
    {
        private static readonly IDictionary<Type, IList<TypeInfo>> ParameterDrawers;

        public static void ForceInitialize()
        {

        }

        public static IEnumerator<TypeInfo> Get(Type supportedType)
        {
            do 
            {
                IList<TypeInfo> els;
                if (ParameterDrawers.TryGetValue(supportedType, out els))
                {
                    foreach (var typeInfo in els)
                        yield return typeInfo;
                }
                supportedType = supportedType.BaseType;
            } while (supportedType != null);
        }

        struct DrawerTempInfo
        {
            public readonly TypeInfo Type;
            public readonly int Order;

            public DrawerTempInfo(TypeInfo type, int order)
            {
                Type = type;
                Order = order;
            }
        }

        public struct TwoTypesKey
        {
            public readonly Type Type1;
            public readonly Type Type2;

            public TwoTypesKey(Type type1, Type type2)
            {
                Type1 = type1;
                Type2 = type2;
            }

            public override int GetHashCode()
            {
                int h1 = Type1 != null ? Type1.GetHashCode() : 0;
                int h2 = Type2 != null ? Type2.GetHashCode() : 0;
                return h1 ^ h2;
            }
        }

        static readonly Dictionary<TwoTypesKey, IList<TypeInfo>> CachedExpressionLists = new Dictionary<TwoTypesKey, IList<TypeInfo>>();

        public static IList<TypeInfo> GetExpressions(Type expectedType = null, Type expressionSubtype = null)
        {
            IList<TypeInfo> list;
            var key = new TwoTypesKey(expectedType, expressionSubtype);
            if (CachedExpressionLists.TryGetValue(key, out list)) return list;

            IEnumerable<TypeInfo> newList = Library.ListExpressionsForExpectedType(expectedType);
            if ((expressionSubtype != null) && (expressionSubtype != typeof(JLExpression)))
                newList = newList.Where(el => expressionSubtype.IsAssignableFrom(el.Type));

            list = new ReadOnlyCollection<TypeInfo>(OrderUnits(newList).ToArray());

            CachedExpressionLists.Add(key, list);
            return list;
        }

        static readonly Dictionary<Type, IList<TypeInfo>> CachedActionLists = new Dictionary<Type, IList<TypeInfo>>();

        public static IList<TypeInfo> GetActions(Type actionSubtype = null)
        {
            if (actionSubtype == null)
                actionSubtype = typeof(JLAction);
            IList<TypeInfo> list;
            if (CachedActionLists.TryGetValue(actionSubtype, out list)) return list;

            IEnumerable<TypeInfo> newList = Library.ListOfType(actionSubtype).ToArray();
            if (actionSubtype.IsAssignableFrom(typeof(JLEvaluteBase)))
                newList = newList
                    .Concat(Library.Expressions.Where(e => (e.UnitUsage == null) || !e.UnitUsage.HideExpressionInActionsList));

            list = new ReadOnlyCollection<TypeInfo>(OrderUnits(newList).ToArray());

            CachedActionLists.Add(actionSubtype, list);

            return list;
        }

        static IEnumerable<TypeInfo> OrderUnits(IEnumerable<TypeInfo> units)
        {
            return units.OrderBy(el => el.UnitUsage != null ? el.UnitUsage.EditorOrder : 0)
                    .ThenBy(el => el.FriendlyName);
        }

        static readonly bool _initStarted;

        static DrawersLibrary()
        {
            if (_initStarted) return;
            _initStarted = true;
            var parameterDrawers = new Dictionary<Type, List<DrawerTempInfo>>();
            foreach (var type in Library.All)
            {
                var drawerAttrs = Attribute.GetCustomAttributes(type, typeof(ParameterDrawerAttribute));
                // ReSharper disable once PossibleInvalidCastExceptionInForeachLoop
                foreach (ParameterDrawerAttribute drawerAttr in drawerAttrs)
                {
                    List<DrawerTempInfo> drawers;
                    if (!parameterDrawers.TryGetValue(drawerAttr.SupportedType, out drawers))
                        parameterDrawers.Add(drawerAttr.SupportedType, drawers = new List<DrawerTempInfo>());
                    drawers.Add(new DrawerTempInfo(type, drawerAttr.Order));
                }
            }

            ParameterDrawers = parameterDrawers.ToDictionary(el => el.Key,
                el => (IList<TypeInfo>)new ReadOnlyCollection<TypeInfo>(el.Value.OrderBy(d => d.Order).Select(d => d.Type).ToArray()));

            var types = FilterTypesRequest(Library.All).ToArray();
            TypesList = new ReadOnlyCollection<string>(types.Select(t => t.Type.FullName).ToArray());
            TypesListShort = new ReadOnlyCollection<string>(types.Select(t => t.Type.Name).ToArray());
            EventsList = new ReadOnlyCollection<string>(Library.Events.Select(t => t.GetType().FullName).ToArray());
            EventsListShort = new ReadOnlyCollection<string>(Library.Events.Select(t => t.GetType().Name).ToArray());
            var enumTypes = types.Where(t => t.Type.IsEnum);
            EnumList = new ReadOnlyCollection<string>(enumTypes.Select(t => t.Type.FullName).ToArray());
            EnumListShort = new ReadOnlyCollection<string>(enumTypes.Select(t => t.Type.Name).ToArray());
            foreach (var action in Library.Actions)
                action.Initialize();
            foreach (var exp in Library.Expressions)
                exp.Initialize();
        }

        static IEnumerable<TypeInfo> FilterTypesRequest(IEnumerable<TypeInfo> types)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var editorAssembly = Assembly.GetAssembly(typeof(UnityEditor.Selection));
            return types
                .Where(t => (t.Type.IsPublic || t.Type.IsNestedPublic) && !t.Type.Name.StartsWith("_"))
                .Where(t => t.Type.Assembly != executingAssembly)
                .Where(t => t.Type.Assembly != editorAssembly)
                .OrderBy(t => string.IsNullOrEmpty(t.Type.Namespace) ? "___" + t.Type.Name : t.Type.Name);
        }

        public readonly static IList<string> TypesList, TypesListShort, EventsList, EventsListShort, EnumList, EnumListShort;
    }
}