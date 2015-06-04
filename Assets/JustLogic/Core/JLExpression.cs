/*
	
	This file is a part of JustLogic product which is distributed under 
	the BSD 3-clause "New" or "Revised" License
	
	Copyright (c) 2015. All rights reserved. 
	Authors: Vladyslav Taranov.
	
	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
	
	* Redistributions of source code must retain the above copyright notice, this
	  list of conditions and the following disclaimer.
	
	* Redistributions in binary form must reproduce the above copyright notice,
	  this list of conditions and the following disclaimer in the documentation
	  and/or other materials provided with the distribution.
	
	* Neither the name of JustLogic nor the names of its
	  contributors may be used to endorse or promote products derived from
	  this software without specific prior written permission.
	
	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
	FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
	DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
	SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
	CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
	OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
	OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

 */
  
using System;
using System.Collections;
using System.Reflection;
using JustLogic.Core;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Base class for unit that does some action and returns a value
/// </summary>
/// <remarks>An expression differs from an action: it has returning value - the result of its work. This value can be immediately used as an argument for another unit.</remarks>
public abstract class JLExpression : JLUnitBase
{
    /// <summary>
    /// Override it to provide your logic for the expression
    /// </summary>
    /// <returns>Value of the specified <see cref="UnitUsageAttribute.ExpressionReturnType"/> type</returns>
    public abstract object GetAnyResult(IExecutionContext context);

    /// <summary>
    /// Creates an expression fluently
    /// </summary>
    public static T Build<T>(Action<T> initializer = null) where T : JLExpression
    {
        var r = CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable<T>() : (T)CreateInstanceFunc(typeof(T));
        if (initializer != null)
            initializer(r);
        return r;
    }
}

public static class JLExpressionExtensions
{

    /// <summary>
    /// Calls <see cref="JLExpression.GetAnyResult"/> if the specified <paramref name="expression"/> is not null, otherwise returns null
    /// </summary>
    public static object GetAnyResultSafe(this JLExpression expression, IExecutionContext context)
    {
        if (expression == null) return null;
        return expression.GetAnyResult(context);
    }

    /// <summary>
    /// Extension method to call the specified expression if it's not null and return its result converted to the specified <typeparamref name="T"/> type
    /// </summary>
    public static T GetResult<T>(this JLExpression expression, IExecutionContext context)
    {
        return (T)GetResult(expression, typeof(T), context);
    }

    /// <summary>
    /// Extension method to call the specified expressions array if it's not null and return the resulting array of the converted to the specified <typeparamref name="T"/> type return values
    /// </summary>
    public static T[] GetResult<T>(this JLExpression[] expressions, IExecutionContext context)
    {
        if (expressions == null || expressions.Length == 0)
            return new T[0];
        var r = new T[expressions.Length];
        for (int i = 0; i < expressions.Length; i++)
        {
            var exp = expressions[i];
            r[i] = exp.GetResult<T>(context);
        }
        return r;
    }

    /// <summary>
    /// Extension method to call the specified expression if it's not null and return its result converted to the specified <paramref name="expectedType"/>
    /// </summary>
    public static object GetResult(this JLExpression expression, Type expectedType, IExecutionContext context)
    {
        if (expression == null)
            return expectedType.IsValueType ? Activator.CreateInstance(expectedType) : null;
        object obj;
        try
        {
            obj = expression.GetAnyResultSafe(context);
        }
        catch
        {
            Debug.LogError("Just Logic Script: execption when execution expression! Something is destroyed or not set?");
            throw;
        }
        return ConvertType(obj, expectedType, context);
    }

    /// <summary>
    /// Helper method that provides conversation functionality
    /// </summary>
    public static object ConvertType(object obj, Type targetType, IExecutionContext context)
    {
        if ((targetType == null) || (targetType == typeof(object)))
            return obj;
        if (targetType == typeof(bool))
        {
            if (obj == null)
                return false;
            var unityObj = obj as Object;
            if (unityObj != null)
                return (bool)unityObj;
        }
        var gameObj = obj as GameObject;
        if ((gameObj != null) && (typeof(Component).IsAssignableFrom(targetType)))
        {
            var c = gameObj.GetComponent(targetType);
            if (c != null) return c;
        }
        if (obj == null)
            return null;
        Type objType = obj.GetType();
        if ((objType == targetType) || (targetType.IsAssignableFrom(objType)))
            return obj;

        if (typeof(JLExpression).IsAssignableFrom(objType) && !typeof(JLExpression).IsAssignableFrom(targetType))
            return ConvertType(((JLExpression)obj).GetAnyResultSafe(context), targetType, context);

        if (objType == typeof(string))
            return obj.ToString();

        if (targetType == typeof(IEnumerable))
        {
            IList array = Array.CreateInstance(objType, 1);
            array[0] = obj;
            return array;
        }

        if (targetType.IsEnum && !objType.IsEnum)
            return Enum.ToObject(targetType, Convert.ChangeType(obj, Enum.GetUnderlyingType(targetType)));

        if (objType.IsEnum)
            return ConvertType(Convert.ChangeType(obj, Enum.GetUnderlyingType(objType)), targetType, context);

        if (targetType == typeof(GameObject) && typeof(Component).IsAssignableFrom(objType))
        {
            return ((Component) obj).gameObject;
        }

        if ((targetType == typeof(Vector3)) && (objType == typeof(Transform)))
            return ((Transform)obj).position;

        if ((targetType == typeof(Quaternion)) && (objType == typeof(Quaternion)))
            return ((Transform)obj).rotation;

        //if (!targetType.IsValueType && !objType.IsValueType)
        {
            TypeInfo from = objType;
            MethodInfo converter = from.TryGetConversationTo(targetType) ?? ((TypeInfo)targetType).TryGetConversationFrom(from);
            if (converter != null)
                return converter.Invoke(null, new[] { obj });
        }
        return Convert.ChangeType(obj, targetType);
    }
    
}

[UnitUsage(typeof(bool))]
public abstract class JLBoolExpression : JLExpression { }
