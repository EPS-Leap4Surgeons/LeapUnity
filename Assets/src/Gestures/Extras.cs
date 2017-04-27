using System;
using UnityEngine.Events;

namespace Gestures
{
    public enum GestureSeqState
    {
        Listening,
        Active
    }

    [Serializable]
    public class RotateEvent : UnityEvent<float, float, float> { }
}
