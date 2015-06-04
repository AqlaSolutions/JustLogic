using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using JustLogic.Core;
using JustLogic.Editor;
using JustLogic.Editor.JLGUI;
using UnityEditor;
using UnityEngine;
using System.Linq;
using Debug = UnityEngine.Debug;

/// <tocexclude />
public abstract class JustLogicScriptEditorBase : JLInspectorBase
{
    [NonSerialized]
    IParameterDrawer _conditionsDrawer;
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
            var script = (JustLogicScriptBase)target;
            JLScriptableHelper.Destroy(script.EngineInstance.Tree);
        }
    }

    protected override void OnDisable()
    {
        ResetDrawers();
        base.OnDisable();
    }

    private void ResetDrawers()
    {
        if (_conditionsDrawer != null)
            _conditionsDrawer.Dispose();
        if (_mainDrawer != null)
            _mainDrawer.Dispose();
        _conditionsDrawer = null;
        _mainDrawer = null;
    }

    protected override bool Draw()
    {
        var script = (JustLogicScriptBase)target;
        if (EditorUtility.IsPersistent(script))
        {
            JLScriptableHelper.AssetsContainer = script;
        }
        if (EditorUtility.IsPersistent(script))
        {
            JLScriptableHelper.AssetsContainer = script;
        }
        bool needsUndo = false;
        try
        {
            var tree = script.EngineInstance.Tree;

            ServiceUndoRedo(typeof(JLAction), tree,
                o =>
                {
                    ResetDrawers();
                    // ReSharper disable once AccessToModifiedClosure
                    JLScriptableHelper.Destroy(tree);
                    script.EngineInstance.Tree = tree = (JLAction)o;
                });

            _drawContext.Reset();
            _drawContext.Inspector = this;
            _drawContext.CurrentVariablesDescriber = script as IScriptVariablesDescriber;
            _drawContext.BeginLook(false);
            bool showed = false;
            GUI.changed = false;

            if (!tree)
            {
                if (Application.isPlaying) return false;

                script.EditorReset();

                tree = script.EngineInstance.Tree;
                needsUndo = true;
            }

            var ifCond = tree as JLIfBase;
            if (ifCond && (!ifCond.Else || ifCond.Else.GetType() == typeof(JLNoopBase)))
            {
                var conditions = ifCond.Value as JLAndBase;
                if (conditions)
                {
                    var sequence = ifCond.Then as JLSequenceBase;
                    if (sequence)
                    {
                        showed = true;

                        if (_mainDrawer == null)
                        {
                            var f = ParameterDrawersFactory.Default;
                            _conditionsDrawer = f.CreateDrawer(
                                new DrawerInitArgs(typeof(JLExpression[]), noHeader: true, defaultUnitType: typeof(JLCompareBase2), expressionType: typeof(bool)),
                                conditions.Operands, _drawContext);

                            _mainDrawer = f.CreateDrawer(
                                new DrawerInitArgs(typeof(JLAction[]),
                                    noHeader: true),
                                sequence.Actions, _drawContext);
                        }

                        _drawContext.BeginVerticalArea(true);
                        GUILayout.Label("Conditions", StylesCache.boldLabel);
                        if ((conditions.Operands == null) || (conditions.Operands.Length == 0))
                            EditorGUILayout.HelpBox("Add conditions which must be satisfied simultaneously or leave empty list. Use button + in the right corner to add item.", MessageType.Info);

                        if (_conditionsDrawer.SimpleDraw(_drawContext))
                        {
                            conditions.Operands = (JLExpression[])_conditionsDrawer.Value;
                            needsUndo = true;
                        }

                        _drawContext.EndArea();

                        _drawContext.BeginVerticalArea(true);
                        GUILayout.Label("Actions", StylesCache.boldLabel);
                        if ((sequence.Actions == null) || (sequence.Actions.Length == 0))
                            EditorGUILayout.HelpBox("Added actions will be executed in a specified order. Use button + in the right corner to add item.", MessageType.Info);

                        if (_mainDrawer.SimpleDraw(_drawContext))
                        {
                            sequence.Actions = (JLAction[])_mainDrawer.Value;
                            needsUndo = true;
                        }

                        _drawContext.EndArea();
                    }
                }


                if (!showed)
                {
                    script.EditorReset();
                    _drawContext.ScheduleRepaint();
                }

                if (_drawContext.NeedsRepaint)
                    Repaint();
            }

        }
        finally
        {
            if (EditorUtility.IsPersistent(script))
            {
                JLScriptableHelper.AssetsContainer = null;
            }
        }
#pragma warning disable 665
        // ReSharper disable once AssignmentInConditionalExpression
        if (_settings = EditorGUILayout.Foldout(_settings, "Settings"))
#pragma warning restore 665
        {
            GUILayout.BeginVertical(StylesCache.box);
            GUILayout.Label("Initialization", StylesCache.boldLabel);
            bool changed = GUI.changed;
            GUI.changed = false;
            script.CtorReentrance = (ExecutionEngineBase.ReentranceMode)EditorGUILayout.EnumPopup("Reentrance", script.CtorReentrance, StylesCache.layerMaskField);
            if (GUI.changed)
                needsUndo = true;
            else if (changed) GUI.changed = true;
            GUILayout.EndVertical();
        }

        return needsUndo;
    }
    [NonSerialized]
    bool _settings;
}
