using JustLogic.Core;
using UnityEngine;

public class JustLogicBehaviorBase : MonoBehaviour
{
    protected virtual void Awake()
    {
        Library.Initialize(Application.isPlaying);
    }
}
