#if !JUSTLOGIC_FREE
using System;
using JustLogic.Core;
using JustLogic.Editor;
using JustLogic.Editor.JLGUI;
using UnityEditor;
using UnityEngine;

/// <tocexclude />
public class JustLogicExpressionHolderEditor : JLInspectorBase
{
    [NonSerialized]
    IParameterDrawer _mainDrawer;
    [NonSerialized]
    DrawContext _drawContext;

    protected override void OnEnable()
    {
        _drawContext = new DrawContext();
        base.OnEnable();
    }

    protected override void OnUndoableScriptReseting()
    {
        if (this)
            ResetDrawers();
        base.OnUndoableScriptReseting();
        if (this)
        {
            var script = (JustLogicSceneExpressionBase)target;
            JLScriptableHelper.Destroy(script.Value);
        }
    }

    protected override void OnDisable()
    {
        ResetDrawers();
        base.OnDisable();
    }

    private void ResetDrawers()
    {
        if (_mainDrawer != null)
            _mainDrawer.Dispose();
        _mainDrawer = null;
    }

    protected override bool Draw()
    {
        var script = (IExpressionHolder)target;

        var expression = script.Value;

        ServiceUndoRedo(typeof(JLExpression), expression,
            o =>
            {
                ResetDrawers();

                // ReSharper disable once AccessToModifiedClosure
                JLScriptableHelper.Destroy(expression);

                script.Value = expression = (JLExpression)o;
            });

        _drawContext.Reset();
        _drawContext.Inspector = this;
        var describer = script as IScriptVariablesDescriber;
        if (describer != null)
            _drawContext.CurrentVariablesDescriber = describer;
        _drawContext.BeginLook(false);

        bool needsUndo = false;
        GUI.changed = false;

        if (_mainDrawer == null)
        {
            _mainDrawer = ParameterDrawersFactory.Default.CreateDrawer(
                new DrawerInitArgs(typeof(JLExpression)), expression, _drawContext);
        }

        _drawContext.BeginVerticalArea(true);
        GUILayout.Label("Expression", StylesCache.boldLabel);

        if (_mainDrawer.SimpleDraw(_drawContext))
        {
            script.Value = expression = (JLExpression)_mainDrawer.Value;
            needsUndo = true;
        }

        _drawContext.EndArea();

        if (_drawContext.NeedsRepaint)
            Repaint();

        return needsUndo;
    }
}

#endif
