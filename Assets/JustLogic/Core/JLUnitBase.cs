using System;
using JustLogic.Core;
using UnityEngine;

/// <summary>
/// Base class for units
/// </summary>
/// <remarks>
/// A JL Script is composed of units - <see cref="JLAction"/> and <see cref="JLExpression"/>.
/// An expression differs from an action: it has returning value - the result of its work. This value can be immediately used as an argument for another unit.<br />
/// Examples of actions: move the object, load level, slow down time.<br />
/// Examples of expressions: find the main camera, compare two numbers, get the length of the string.<br />
/// </remarks>
public abstract class JLUnitBase : JLScriptable
{
    public static Func<Type, ScriptableObject> CreateInstanceFunc;


    /// <summary>
    /// ScriptableObject.CreateInstance shortcut
    /// </summary>
    public new static T CreateInstance<T>() where T : ScriptableObject
    {
        return (T)(CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable<T>() : CreateInstanceFunc(typeof(T)));
    }
    
    /// <summary>
    /// ScriptableObject.CreateInstance shortcut
    /// </summary>
    public new static ScriptableObject CreateInstance(Type type)
    {
        return CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable(type) : CreateInstanceFunc(type);
    }

    /// <summary>
    /// ScriptableObject.CreateInstance shortcut
    /// </summary>
    public new static ScriptableObject CreateInstance(string classname)
    {
        return CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable(classname) : CreateInstanceFunc(Library.FindType(classname));
    }

    /// <summary>
    /// Weather unit is expanded in the inspector
    /// </summary>
    public bool Expanded = true;

}
