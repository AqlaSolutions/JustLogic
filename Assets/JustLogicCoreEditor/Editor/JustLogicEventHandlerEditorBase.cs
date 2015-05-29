using System;
using System.Reflection;
using JustLogic.Core;
using JustLogic.Core.Events;
using JustLogic.Editor;
using JustLogic.Editor.JLGUI;
using JustLogic.Editor.JLGUI.Drawers;
using UnityEditor;
using UnityEngine;
using System.Linq;

/// <tocexclude />
public abstract class JustLogicEventHandlerEditorBase : JLInspectorBase
{
    [NonSerialized]
    IParameterDrawer _conditionsDrawer;
    [NonSerialized]
    IParameterDrawer _scriptsLookupDrawer;
    [NonSerialized]
    IParameterDrawer _eventSelectorDrawer;
    [NonSerialized]
    DrawContext _drawContext;

    protected override void OnEnable()
    {
        _drawContext = new DrawContext();

        var script = (JustLogicEventHandlerCoreBase)this.target;
        if (script != null)
            script.OnRuntimeInspectorFieldsChanged += script_OnRuntimeInspectorFieldsChanged;

        base.OnEnable();
    }

    void script_OnRuntimeInspectorFieldsChanged()
    {
        if (this)
            Repaint();
    }

    protected override void OnUndoableScriptReseting()
    {
        if (this)
            ResetDrawers();
        base.OnUndoableScriptReseting();
        if (this)
        {
            var data = ((JustLogicEventHandlerCoreBase)this.target).EventHandlerData;
            DestroyData(data);
        }
    }

    private static void DestroyData(JustLogicEventHandlerCoreBase.EventHandlerDataHolder data)
    {
        if (data != null)
        {
            JLScriptableHelper.Destroy(data.Condition);
            JLScriptableHelper.Destroy(data.EventDataClassFullName);
            if (data.JLScriptsLookup != null)
                foreach (var exp in data.JLScriptsLookup)
                    JLScriptableHelper.Destroy(exp);
            data.JLScriptsLookup = new JLExpression[0];
        }
    }

    protected override void OnDisable()
    {
        var script = (JustLogicEventHandlerCoreBase)this.target;
        if (script != null)
            script.OnRuntimeInspectorFieldsChanged -= script_OnRuntimeInspectorFieldsChanged;

        ResetDrawers();
        base.OnDisable();
    }

    private void ResetDrawers()
    {
        if (_conditionsDrawer != null)
            _conditionsDrawer.Dispose();
        if (_scriptsLookupDrawer != null)
            _scriptsLookupDrawer.Dispose();
        if (_eventSelectorDrawer != null)
            _eventSelectorDrawer.Dispose();
        _conditionsDrawer = null;
        _scriptsLookupDrawer = null;
        _eventSelectorDrawer = null;
    }

    protected override bool Draw()
    {
        var script = (JustLogicEventHandlerCoreBase)this.target;

        var data = script.EventHandlerData;

        if (Application.isPlaying)
        {
            GUILayout.Label("Triggered counter: " + script.TriggeredCounter);
        }

        if ((data == null) || !data.Condition || !(data.Condition is JLAndBase))
        {
            if (Application.isPlaying) return false;
            script.EditorReset();
        }

        ServiceUndoRedo(typeof(JustLogicEventHandlerCoreBase.EventHandlerDataHolder), data,
            o =>
            {
                ResetDrawers();
                DestroyData(data);
                script.EventHandlerData = data = (JustLogicEventHandlerCoreBase.EventHandlerDataHolder)o;
            });

        _drawContext.Reset();
        _drawContext.Inspector = this;
        _drawContext.CurrentVariablesDescriber = script as IScriptVariablesDescriber;
        _drawContext.BeginLook(false);
        bool needsUndo = false;
        GUI.changed = false;

        var conditions = (JLAndBase)data.Condition;

        var f = ParameterDrawersFactory.Default;
        if (_scriptsLookupDrawer == null)
        {
            _scriptsLookupDrawer = f.CreateDrawer(
                new DrawerInitArgs(typeof(JLExpression[]), noHeader: true, expressionType: typeof(JustLogicScriptBase)),
                data.JLScriptsLookup, _drawContext);
        }

        if (_eventSelectorDrawer == null)
        {
            _eventSelectorDrawer = f.CreateDrawer(
                new DrawerInitArgs(typeof(string), drawerType: typeof(EventDrawer)),
                data.EventDataClassFullName, _drawContext);
        }

        _drawContext.BeginVerticalArea(true);
        if (_eventSelectorDrawer.SimpleDraw(_drawContext))
        {
            var newValue = (string)_eventSelectorDrawer.Value;

            var newEvent = Library.Events.FirstOrDefault(ev => ev.GetType().FullName == newValue);
            if (newEvent != null)
            {
                if (newEvent.RequiredEventHandler != script.GetType().FullName)
                {
                    Undo.RegisterSceneUndo("JL Script");

                    data.EventDataClassFullName = newValue;

                    JustLogicEventHandlerCoreBase handler = (JustLogicEventHandlerCoreBase)script.gameObject.AddComponent(Library.FindType(newEvent.RequiredEventHandler));
                    handler.EventHandlerData = script.EventHandlerData;
                    script.EventHandlerData = null;
                    DestroyImmediate(script, true);
                    _drawContext.EndAllAreas();
                    return false;
                }
            }
            data.EventDataClassFullName = newValue;

            needsUndo = true;
            if (_conditionsDrawer != null)
            {
                _conditionsDrawer.Dispose();
                _conditionsDrawer = null;
            }
        }
        _drawContext.EndArea();

        try
        {
            _drawContext.CurrentEditingEvent = ((IEventDescription)Activator.CreateInstance(Library.FindType(script.EventHandlerData.EventDataClassFullName)));
        }
        catch { _drawContext.CurrentEditingEvent = null; }


        _drawContext.BeginVerticalArea(true);
        GUILayout.Label("Trigger Scripts:", StylesCache.boldLabel);
        _drawContext.BeginHorizontalArea();
        GUILayout.Space(15f);
        _drawContext.BeginVerticalArea();
        if (_scriptsLookupDrawer.SimpleDraw(_drawContext))
        {
            data.JLScriptsLookup = (JLExpression[])_scriptsLookupDrawer.Value;
            needsUndo = true;
        }
        _drawContext.EndArea();
        _drawContext.EndArea();
        _drawContext.SetCheckChanged(ref needsUndo, () => script.DisableOnTriggered = EditorGUILayout.Toggle("And Disable Event Handler", script.DisableOnTriggered));
        _drawContext.EndArea();

        _drawContext.BeginVerticalArea(true);
        GUILayout.Label("Conditions", StylesCache.boldLabel);
        if ((conditions.Operands == null) || (conditions.Operands.Length == 0))
            EditorGUILayout.HelpBox("Add conditions which must be satisfied simultaneously or leave empty list. Use button + in the right corner to add item.", MessageType.Info);

        if (_conditionsDrawer == null)
            CreateConditionsDrawer(f, conditions, GetDefaultConditionUnitType());

        if (_conditionsDrawer.SimpleDraw(_drawContext))
        {
            conditions.Operands = (JLExpression[])_conditionsDrawer.Value;
            needsUndo = true;
        }
        _drawContext.EndArea();


        if (_drawContext.NeedsRepaint)
            Repaint();
        return needsUndo;
    }

    protected Type GetDefaultConditionUnitType()
    {
        return (_drawContext.CurrentEditingEvent != null && _drawContext.CurrentEditingEvent.Arguments.Count == 0)
                   ? Library.FindType("JLCompare")
                   : Library.FindType("JLCompareEventArgument");
    }

    private void CreateConditionsDrawer(IParameterDrawersFactory f, JLAndBase conditions, Type defaultUnitType)
    {
        _conditionsDrawer = f.CreateDrawer(
            new DrawerInitArgs(typeof(JLExpression[]), noHeader: true, expressionType: typeof(bool),
                               defaultUnitType: defaultUnitType),
            conditions.Operands, _drawContext);
    }
}
