using System;
using JustLogic.Core;
using JustLogic.Core.Events;
using UnityEngine;

/// <tocexclude />
[ExecuteInEditMode]
public abstract class JustLogicEventHandlerCoreBase : JustLogicScriptableContainerBase
{
    [Serializable]
    public class EventHandlerDataHolder
    {
        public string EventDataClassFullName;
        public JLExpression Condition;

        /// <summary>
        /// Can be found via tag, for example
        /// </summary>
        public JLExpression[] JLScriptsLookup;
    }

    public EventHandlerDataHolder EventHandlerData = new EventHandlerDataHolder();

    protected override void Reset()
    {
        if (EventHandlerData == null)
            EventHandlerData = new EventHandlerDataHolder();
        base.Reset();
        EventHandlerData.Condition = JLUnitBase.CreateInstance<JLAndBase>();
        JLObjectValueBase objValue;
        EventHandlerData.JLScriptsLookup = new JLExpression[] { objValue = JLUnitBase.CreateInstance<JLObjectValueBase>() };
        EventHandlerData.EventDataClassFullName = typeof(Awake).FullName;
        objValue.Value = gameObject.GetComponent<JustLogicScriptBase>();
    }

    protected override void Awake()
    {
        if (EventHandlerData == null)
            EventHandlerData = new EventHandlerDataHolder();
        EnsureEditorInited();
        base.Awake();
    }

    [NonSerialized]
    readonly static object[] EmptyArgs = new object[0];

    /// <summary>
    /// Handles the specified event if its of the handling event type and the event handler is enabled
    /// </summary>
    /// <remarks>Adances <see cref="TriggeredCounter"/></remarks>
    public void Trigger(IEventDescription desc)
    {
        Trigger(desc, EmptyArgs);
    }

    public bool DisableOnTriggered;

    public int TriggeredCounter { get; private set; }
    public void ResetTriggeredCounter()
    {
        TriggeredCounter = 0;
        if (OnRuntimeInspectorFieldsChanged != null)
            OnRuntimeInspectorFieldsChanged();
    }

    public event Action OnRuntimeInspectorFieldsChanged;

    /// <summary>
    /// Handles the specified event if its of the handling event type and the event handler is enabled (with argumnets)
    /// </summary>
    /// <remarks>Adances <see cref="TriggeredCounter"/></remarks>
    /// <param name="desc">Event description object</param>
    /// <param name="arguments">Concrete event arguments (should be consistent with <see cref="IEventDescription.Arguments"/>)</param>
    public void Trigger(IEventDescription desc, params object[] arguments)
    {
        if (!Application.isPlaying || !enabled) return;
        if (desc.GetType().FullName != EventHandlerData.EventDataClassFullName)
            return;
        TriggeredCounter++;
        var eventData = new EventData(desc, arguments, this, TriggeredCounter);
        if (OnRuntimeInspectorFieldsChanged != null)
            OnRuntimeInspectorFieldsChanged();
        var context = new ExecutionContext { CurrentEvent = eventData, ExecutorObject = gameObject, ExecutorBehavior = this };
        if (!EventHandlerData.Condition.GetResult<bool>(context))
            return;
        if (DisableOnTriggered)
            enabled = false;
        foreach (JLExpression objValue in EventHandlerData.JLScriptsLookup)
        {
            var script = objValue.GetResult<JustLogicScriptBase>(context);
            if (script)
                script.StartExecutionByEvent(eventData);
        }
    }

    public override object EditorScriptData { get { return EventHandlerData; } set { EventHandlerData = (EventHandlerDataHolder)value; } }

    [NonSerialized]
    bool _editorInited;

    private void EnsureEditorInited()
    {
        if (!_editorInited && Application.isEditor)
        {
            _editorInited = true;
            EditorOnAfterDuplicated += () => EditorEventsMediator.OnEventHandlerDuplicated(this);
        }
    }

    protected override void OnEnable()
    {
        EnsureEditorInited();
        base.OnEnable();
    }

}