#if !JUSTLOGIC_FREE
using System;
using JustLogic.Core;
using JustLogic.Editor;
using JustLogic.Editor.JLGUI;
using UnityEditor;
using UnityEngine;

/// <tocexclude />
[CustomEditor(typeof(JustLogicTimerBase))]
public class JustLogicTimerEditor : JLInspectorBase
{
    [NonSerialized]
    IParameterDrawer _receiverDrawer;
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
    }

    protected override void OnDisable()
    {
        ResetDrawers();
        base.OnDisable();
    }

    private void ResetDrawers()
    {
        if (_receiverDrawer != null)
            _receiverDrawer.Dispose();
        _receiverDrawer = null;
    }

    protected override bool Draw()
    {
        var script = (JustLogicTimerBase)target;

        _drawContext.Reset();
        _drawContext.Inspector = this;

        _drawContext.BeginLook(false);

        bool needsUndo = false;



        if (_receiverDrawer == null)
        {
            _receiverDrawer = ParameterDrawersFactory.Default.CreateDrawer(
                new DrawerInitArgs(typeof(UnityEngine.Object)), script.Receiver, _drawContext);
        }

        _drawContext.BeginHorizontalArea();
        GUILayout.Label("Receiver", StylesCache.boldLabel);

        if (_receiverDrawer.SimpleDraw(_drawContext))
        {
            script.Receiver = (UnityEngine.Object)_receiverDrawer.Value;
            needsUndo = true;
        }
        _drawContext.EndArea();
        if (script.Receiver)
        {
            if (script.Receiver is JustLogicScriptBase)
                EditorGUILayout.HelpBox("The selected object is JL Script so it is called directly.", MessageType.Info);
            else if (script.Receiver is JustLogicEventHandlerCoreBase)
                EditorGUILayout.HelpBox("The selected object is JL Event Handler. You can specify conditons in its inspector.", MessageType.Info);
            else if (script.Receiver is GameObject)
                EditorGUILayout.HelpBox("The selected object is GameObject. All JL Event Handlers are triggered. None of JL Scripts are called directly.", MessageType.Info);
            else if (script.Receiver is MonoBehaviour)
                EditorGUILayout.HelpBox("The selected object is script. You can handle event OnJLTimerTick(JustLogicTimer timer) inside it.", MessageType.None);
            else EditorGUILayout.HelpBox("The selected object is not supported", MessageType.Warning);
        }

        GUI.changed = false;
        script.Interval = EditorGUILayout.FloatField("Interval", script.Interval);
        script.Once = EditorGUILayout.Toggle("Once", script.Once);
        if (GUI.changed)
            needsUndo = true;

        if (_drawContext.NeedsRepaint)
            Repaint();

        return needsUndo;
    }
}

#endif
