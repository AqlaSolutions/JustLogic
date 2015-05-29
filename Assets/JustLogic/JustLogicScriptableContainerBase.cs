using System;
using JustLogic.Core;
using UnityEngine;

/// <tocexclude />
public abstract class JustLogicScriptableContainerBase : JustLogicBehaviorBase, IUndoableBehavior
{
    UndoDataBase IUndoableBehavior.UndoData { get { return UndoDataAccessor; } }
    protected abstract UndoDataBase UndoDataAccessor { get; set; }
    protected abstract UndoDataBase CreateUndoData();

    [SerializeField]
    [System.Reflection.ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
    JustLogicScriptableReferenceId _editorScriptRef;

    [SerializeField]
    [System.Reflection.ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
    public UnityEngine.Object[] EditorRelativeReferences;

    public abstract object EditorScriptData { get; set; }

    [SerializeField]
    [System.Reflection.ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
    public int StoredInstanceId;

    protected override void Awake()
    {
        base.Awake();
        StoredInstanceId = this.GetInstanceID();
        UndoDataAccessor = CreateUndoData();
        if (!Application.isPlaying)
        {
            var d = EditorEventsMediator.OnAwakeCalled;
            if (d != null) d(this);
            CheckDuplicated();
        }
    }

    protected JustLogicScriptableContainerBase()
    {
        var d = EditorEventsMediator.OnConstructorCalled;
        if (d != null) d(this);
    }

    public event Action EditorOnAfterDuplicated;
    public event Action EditorOnReseting;

    private void CheckDuplicated()
    {
        if (!_editorScriptRef)
        {
            SetEditorScriptRef();
        }
        else if (_editorScriptRef.Behaviour != this)
        {
            var d = EditorOnAfterDuplicated;
            if (d != null) d();
            SetEditorScriptRef();
        }
    }

    private void SetEditorScriptRef()
    {
        _editorScriptRef = Library.Instantiator.CreateScriptable<JustLogicScriptableReferenceId>();
        _editorScriptRef.Behaviour = this;
    }

    protected virtual void OnEnable()
    {
        UndoDataAccessor = CreateUndoData();
    }

    protected virtual void Update()
    {
        StoredInstanceId = this.GetInstanceID();
        if (!Application.isPlaying)
        {
            CheckDuplicated();
        }
    }

    public void EditorReset()
    {
        if (!Application.isPlaying)
            Reset();
    }

    protected virtual void Reset()
    {
        if (UndoDataAccessor != null)
            UndoDataAccessor.UndoIndex = UndoDataAccessor.UndoPersistentIndex;
        var d = EditorOnReseting;
        if (d != null) d();
    }

}
