using JustLogic.Core;
using UnityEngine;

public class JLScriptable : ScriptableObject
{
    protected virtual void OnDestroy()
    {

    }

    protected virtual void OnDisable()
    {

    }

    protected virtual void OnEnable()
    {
        Library.Initialize(Application.isPlaying);
    }

}
