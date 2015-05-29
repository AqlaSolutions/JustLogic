#if !JUSTLOGIC_FREE
using System;
using JustLogic.Core;
using UnityEngine;

[UnitFriendlyName("Create Instance")]
[UnitMenu("Object/Create New")]
[UnitMenu("External/Construct")]
public class JLCreateNew : JLExpression
{
    [Parameter(ExpressionType = typeof(Type))]
    public JLExpression Type;

    [Parameter]
    public JLExpression[] ConstructorArguments;

    public override object GetAnyResult(IExecutionContext context)
    {
        var v = Type.GetResult<Type>(context);
        if (v.IsAbstract)
            return null;
        if (v.IsArray)
            return Array.CreateInstance(v.GetElementType(), 0);
        if (typeof(ScriptableObject).IsAssignableFrom(v))
            return Library.Instantiator.CreateScriptable(v);
        var args = new object[ConstructorArguments != null ? ConstructorArguments.Length : 0];
        if (args.Length != 0)
            for (int i = 0; i < ConstructorArguments.Length; i++)
            {
                var arg = ConstructorArguments[i];
                args[i] = arg.GetAnyResultSafe(context);
            }
        return Activator.CreateInstance(v, args);
    }
}

#endif
