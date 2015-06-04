using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JustLogic.Editor
{
    [InitializeOnLoad]
    public static class JLScriptableHelper
    {
        static JLScriptableHelper()
        {
            JLUnitBase.CreateInstanceFunc = CreateNew;
        }

        static void CollectDestroyReferencesRecursively(object obj, ref HashSet<object> refs, JLScriptable main)
        {
            CollectReferencesRecursively(obj, ref refs, val => CheckAssetDestroyable(main, val));
        }

        public static void CollectReferencesRecursively(object obj, ref HashSet<object> refs, Predicate<object> predicate)
        {
            if (refs == null)
                refs = new HashSet<object> { obj };
            TypeInfo tInfo = obj.GetType();
            if ((tInfo.JustLogicParameters != null) && (tInfo.JustLogicParameters.List != null))
                foreach (var p in tInfo.JustLogicParameters.List)
                {
                    if (p.Type.IsArray)
                    {
                        var vals = (IList)p.Getter(obj);
                        if (vals != null)
                            foreach (object val in vals)
                            {
                                if (predicate(val) && refs.Add(val))
                                    CollectReferencesRecursively(val, ref refs, predicate);
                            }
                    }
                    else
                    {
                        var val = p.Getter(obj);
                        if (predicate(val) && refs.Add(val))
                            CollectReferencesRecursively(val, ref refs, predicate);
                    }
                }
        }

        private static bool CheckAssetDestroyable(JLScriptable main, object v)
        {
            var val = v as ScriptableObject;
            return val && ((val.hideFlags & HideFlags.DontSave) == 0) &&
                   (
                       !AssetDatabase.IsMainAsset(val)  // ссылка на другой ассет не добавляется
                       &&
                       (!AssetDatabase.IsSubAsset(val) // добавляется только не-ассет или ассет с тем же путем
                        || (AssetDatabase.GetAssetPath(val) == AssetDatabase.GetAssetPath(main)))
                   );
        }


        public static void Destroy(object scriptable)
        {
            Destroy(scriptable as ScriptableObject);
        }

        public static void Destroy(ScriptableObject scriptable)
        {
            if (!scriptable) return;
            var unit = scriptable as JLUnitBase;
            if (!unit)
            {
                Object.DestroyImmediate(scriptable, true);
                return;
            }

            HashSet<object> refs = null;
            CollectDestroyReferencesRecursively(unit, ref refs, unit);
            foreach (var scriptableObject in refs.Cast<ScriptableObject>().ToArray())
            {
                if (scriptableObject)
                {
                    //Debug.Log("destroying " + scriptableObject.GetType().Name);
                    Object.DestroyImmediate(scriptableObject, true);
                }
            }
        }

        public static Object AssetsContainer { get; set; }

        public static T CreateNew<T>() where T : JLScriptable
        {
            return (T)CreateNew(typeof(T));
        }

        public static JLScriptable CreateNew(Type type)
        {
            var obj = (JLScriptable)Library.Instantiator.CreateScriptable(type);
            if (AssetsContainer)
            {
                obj.hideFlags = HideFlags.HideInHierarchy;
                AssetDatabase.AddObjectToAsset(obj, AssetsContainer);
            }
            return obj;
        }


        public static TNeededType WrapUnitIfNeed<TNeededType>(object unit) where TNeededType : class
        {
            var newTType = unit.GetType();
            if (typeof(JLExpression).IsAssignableFrom(newTType) && typeof(JLAction).IsAssignableFrom(typeof(TNeededType)))
            {
                var b = CreateNew<JLEvaluteBase>();
                if (b.Expression)
                    Destroy(b.Expression);
                b.Expression = (JLExpression)CreateNew(newTType);
                if (!(b is TNeededType))
                    throw new ArgumentException();
                return b as TNeededType;
            }
            if (!(unit is TNeededType))
                throw new ArgumentException();
            return unit as TNeededType;
        }

        public static object WrapUnitIfNeed(object unit, Type neededType)
        {
            var newTType = unit.GetType();
            if (typeof(JLExpression).IsAssignableFrom(newTType) && typeof(JLAction).IsAssignableFrom(neededType))
            {
                var b = CreateNew<JLEvaluteBase>();
                if (b.Expression)
                    Destroy(b.Expression);
                b.Expression = (JLExpression)CreateNew(newTType);
                return b;
            }
            return unit;
        }

        public static TUnitType ReplaceUnitSubtype<TUnitType>(TUnitType unit, TypeInfo neededSubtype) where TUnitType : JLScriptable
        {
            return (TUnitType)ReplaceUnitSubtype(unit, typeof(TUnitType), neededSubtype);
        }

        public static JLScriptable ReplaceUnitSubtype(JLScriptable unit, Type baseType, TypeInfo newSubtype)
        {
            if (newSubtype == null)
            {
                Destroy(unit);
                return null;
            }
            if (typeof(JLExpression).IsAssignableFrom(newSubtype) && typeof(JLAction).IsAssignableFrom(baseType))
            {
                // assigning expression to action? ok!
                var b = (unit = ReplaceUnitSubtypeInternal(unit, typeof(JLEvaluteBase))) as JLEvaluteBase;
                if (b.Expression)
                    Destroy(b.Expression);
                b.Expression = (JLExpression)CreateNew(newSubtype);
                return unit;
            }
            return ReplaceUnitSubtypeInternal(unit, newSubtype);
        }

        /// <summary>
        /// ReplaceUnitSubtype without wrapping in Evalute
        /// </summary>
        private static JLScriptable ReplaceUnitSubtypeInternal(JLScriptable unit, TypeInfo neededSubtype)
        {
            if (unit && (unit.GetType() != neededSubtype.Type))
                return ReplaceUnit(unit, neededSubtype);
            else if (!unit)
                unit = CreateNew(neededSubtype);
            return unit;
        }

        public static TUnitType ReplaceUnit<TUnitType, TNeededSubtype>(TUnitType unit) where TUnitType : JLScriptable
        {
            return ReplaceUnit(unit, typeof(TNeededSubtype));
        }

        private static TUnitType ReplaceUnit<TUnitType>(TUnitType unit, Type neededSubtype) where TUnitType : JLScriptable
        {
            TUnitType prevUnit = unit;
            var newUnit = (TUnitType)CreateNew(neededSubtype);
            var newUnitPars = UnitParameters.Get(neededSubtype);
            var newUnitParameters = newUnitPars.List;
            TypeInfo prevUnitType = prevUnit.GetType();
            var prevUnitPars = UnitParameters.Get(prevUnitType);
            var prevUnitParameters = prevUnitPars.List;

            if ((prevUnit is JLAction) && (newUnit is JLSequenceBase))
            {
                var sequence = newUnit as JLSequenceBase;
                if (sequence.Actions == null)
                    sequence.Actions = new JLAction[0];
                ArrayUtility.Add(ref sequence.Actions, prevUnit as JLAction);
            }
            else
            {
                var notUsedPrevParameters = new List<UnitParameter>(prevUnitParameters);
                var notUsedNewParameters = new List<UnitParameter>(newUnitParameters);
                for (int i = 0; i < notUsedPrevParameters.Count; i++)
                {
                    var prevParam = notUsedPrevParameters[i];
                    UnitParameter newParam = notUsedNewParameters.FirstOrDefault(p => p.Name == prevParam.Name);
                    if ((newParam == null) || !newParam.Type.IsAssignableFrom(prevParam.Type)) continue;

                    // параметр с тем же именем и подходящим типом
                    if (newParam.Type.IsValueType)
                    {
                        newParam.Setter(newUnit, prevParam.Getter(prevUnit));
                        notUsedNewParameters.Remove(newParam);
                        notUsedPrevParameters.RemoveAt(i--);
                    }
                    else
                    {
                        var v = prevParam.Getter(prevUnit);
                        if (v != null)
                        {
                            var typeInfo = ((TypeInfo)v.GetType());
                            if (typeInfo.IsAssignableTo(newParam))
                            {

                                notUsedNewParameters.Remove(newParam);

                                if (prevUnitType != neededSubtype
                                    && typeof(JLExpression).IsAssignableFrom(prevParam.Type)
                                    && ((newParam.ExpressionType == null)
                                        || (prevParam.TypeInfo.UnitUsage == null || prevParam.TypeInfo.UnitUsage.ExpressionReturnType == null))
                                    && Copier.GetCompexity(v) <= 3)
                                    continue; // не берем JLExpression без указанного Return Type

                                MoveParameterReferenceValue(v, typeInfo, prevUnit, prevParam, newUnit, newParam);

                                notUsedPrevParameters.RemoveAt(i--);
                            }
                        }
                    }
                }

                foreach (var parameter in notUsedPrevParameters)
                {
                    if (parameter.Type.IsPrimitive) continue;
                    var v = parameter.Getter(prevUnit);
                    if (v == null)
                        continue;
                    var typeInfo = ((TypeInfo)v.GetType());
                    bool isExpr = typeof(JLExpression).IsAssignableFrom(typeInfo);
                    if (isExpr && (typeInfo.UnitUsage == null || typeInfo.UnitUsage.ExpressionReturnType == null)) continue;
                    var match = notUsedNewParameters.Where(typeInfo.IsAssignableTo).FirstOrDefault(el => !isExpr || el.ExpressionType != null);
                    if (match == null)
                        continue;

                    MoveParameterReferenceValue(v, typeInfo, prevUnit, parameter, newUnit, match);

                    notUsedNewParameters.Remove(match);
                }

                Destroy(prevUnit);
            }
            return newUnit;
        }

        private static void MoveParameterReferenceValue(object value, TypeInfo valueTypeInfo, object prevUnit, UnitParameter prevParameter, object newUnit, UnitParameter newParameter)
        {
            if (valueTypeInfo.IsUnityObject)
                Destroy(newParameter.Getter(newUnit));

            newParameter.Setter(newUnit, value);

            if (!valueTypeInfo.Type.IsValueType)
                prevParameter.Setter(prevUnit, null);
        }

        public static TypeInfo GetUnitDefaultSubtype(IList<TypeInfo> variants, UnitParameter parameter)
        {
            if (parameter == null) return null;
            if ((parameter.DefaultUnitType != null) && variants.Any(v => v.Type == parameter.DefaultUnitType))
                return parameter.DefaultUnitType;

            if (variants.Count == 0) return null;

            int index = -1;

            int indexOfNoop = variants.IndexOf(typeof(JLNoopBase));
            if (indexOfNoop != -1)
                index = indexOfNoop;
            else
            {
                if (typeof(JLExpression).IsAssignableFrom(parameter.Type) && parameter.ExpressionType != null)
                {
                    var parTypeMainAlias = TypeKey.GetMainAlias(parameter.ExpressionType);
                    var defaultVariant = variants
                        .Where(v => v.UnitUsage != null)
                        .Where(v => v.UnitUsage.IsDefaultExpression)
                        .OrderBy(v =>
                            Math.Min(TypeInfo.GetDifference(TypeKey.GetMainAlias(v.UnitUsage.ExpressionReturnType), parTypeMainAlias),
                                    TypeInfo.GetDifference(v.UnitUsage.ExpressionReturnType, parTypeMainAlias)))
                        .FirstOrDefault();
                    if (defaultVariant != null) index = variants.IndexOf(defaultVariant);
                }

                if (index == -1)
                {
                    // создаваемый по умолчанию блок не должен быть массивом или содержать другие блоки
                    index = 0;
                    int bestIndex = -1;
                    for (int i = 0; i < variants.Count; i++)
                    {
                        var v = variants[i];
                        if (!parameter.Type.IsAssignableFrom(v)) continue;
                        if ((v.JustLogicParameters == null)
                            || (v.JustLogicParameters.List.Count == 0)
                            || (v.JustLogicParameters.List.All(p => p.Type.IsValueType || p.Type == typeof(string))))
                        {
                            if (v.UnitMenus.Any(m => m.StartsWith("Value/")))
                            {
                                if ((bestIndex == -1)
                                    || (variants[bestIndex].Type == typeof(JLNullReferenceBase))
                                    || !variants[bestIndex].Type.Name.EndsWith("Value")
                                    || ((v.UnitUsage != null) && (v.UnitUsage.ExpressionReturnType != null) && (parameter.ExpressionType != null)
                                    && (v.UnitUsage.ExpressionReturnType.IsAssignableFrom(parameter.ExpressionType)
                                    || parameter.ExpressionType.Type.IsAssignableFrom(v.UnitUsage.ExpressionReturnType))))
                                    bestIndex = i;

                            }
                            index = i;
                        }
                    }
                    if (bestIndex != -1)
                        index = bestIndex;
                }
            }
            return variants[index];
        }

    }
}