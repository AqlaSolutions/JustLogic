#if !JUSTLOGIC_FREE
using System;
using JustLogic.Core;
using JustLogic.Editor;
using JustLogic.Editor.JLGUI;
using UnityEditor;
using UnityEngine;

/// <tocexclude />
public class JLCustomScriptAssetEditorBase : JLInspectorBase
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
        var script = (JLCustomScriptAssetBase)this.target;

        var prevAssetsContainer = JLScriptableHelper.AssetsContainer;
        JLScriptableHelper.AssetsContainer = script;
        try
        {
            _drawContext.Reset();
            _drawContext.Inspector = this;
            _drawContext.CurrentVariablesDescriber = script as IScriptVariablesDescriber;
            _drawContext.BeginLook(false);
            bool needsUndo = false;

            if (!script.Value)
                script.Value = JLScriptableHelper.CreateNew<JLSequenceBase>();

            _drawContext.BeginVerticalArea(true);
            GUILayout.Label("Actions", StylesCache.boldLabel);
            if ((script.Value.Actions == null) || (script.Value.Actions.Length == 0))
                EditorGUILayout.HelpBox("Added actions will be executed in a specified order. Use button A in the right corner to add item.", MessageType.Info);

            var sequence = script.Value;

            ServiceUndoRedo(typeof(JLSequenceBase), sequence,
                o =>
                {
                    ResetDrawers();

                    JLScriptableHelper.Destroy(sequence);

                    script.Value = sequence = (JLSequenceBase)o;
                });

            if (_mainDrawer == null)
            {
                var f = ParameterDrawersFactory.Default;

                _mainDrawer = f.CreateDrawer(
                    new DrawerInitArgs(typeof(JLAction[]),
                        noHeader: true),
                    sequence.Actions, _drawContext);
            }

            if (_mainDrawer.SimpleDraw(_drawContext))
            {
                script.Value.Actions = (JLAction[])_mainDrawer.Value;
                needsUndo = true;
            }

            _drawContext.EndArea();

            if (_drawContext.NeedsRepaint)
                Repaint();

            return needsUndo;
        }
        finally { JLScriptableHelper.AssetsContainer = prevAssetsContainer; }
    }
}

#endif
