#if !JUSTLOGIC_FREE
using JustLogic.Core;
using UnityEngine;

/// <summary>
/// Allows you to store the reference to a specified object into the global variable
/// </summary>
/// <remarks>Can be useful if you have one object in a one scene and want to access it from another additively loaded scene. Access the stored ("marked") object with <see cref="GlobalVariablesStorage"/> or Variable units.</remarks>
[AddComponentMenu("Just Logic/JL Marker")]
public class JustLogicMarker : JustLogicMarkerBase
{
}
#endif