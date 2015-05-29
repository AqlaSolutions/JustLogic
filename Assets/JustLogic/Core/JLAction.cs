using System;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

/// <summary>
/// Base class for unit that does some action
/// </summary>
/// <remarks>
/// Actions are not available to be used as expression parameters. An action does not return a value, so it cannot be passed in the parameter.
/// </remarks>
public abstract class JLAction : JLUnitBase
{
    /// <summary>
    /// Weather the unit is enabled to be executed
    /// </summary>
    public bool On = true;

    /// <summary>
    /// Override it to provide your logic for the action
    /// </summary>
    /// <param name="context">Execution information</param>
    /// <returns>null or <see cref="YieldMode"/> to start coroutine</returns>
    protected abstract IEnumerator<YieldMode> OnExecute(IExecutionContext context);

    /// <summary>
    /// Executes the action if it's enabled, otherwise returns null
    /// </summary>
    public IEnumerator<YieldMode> Execute(IExecutionContext context)
    {
        if (!On)
            return null;

        return OnExecute(context);
    }

    /// <summary>
    /// Creates an action fluently
    /// </summary>
    public static T Build<T>(System.Action<T> initializer = null) where T : JLAction
    {
        var r = CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable<T>() : (T)CreateInstanceFunc(typeof(T));
        if (initializer != null)
            initializer(r);
        return r;
    }

}

public static class JLActionExtensions
{
    /// <summary>
    /// Calls <see cref="JLAction.Execute"/> if the specified <paramref name="action"/> is not null, otherwise returns null
    /// </summary>
    public static IEnumerator<YieldMode> ExecuteSafe(this JLAction action, IExecutionContext context)
    {
        if (action == null) return null;
        return action.Execute(context);
    }

}