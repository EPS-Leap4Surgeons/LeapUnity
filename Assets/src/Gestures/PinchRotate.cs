using System;
using UnityEngine.Events;
using Leap.Unity;
using UnityEngine;

namespace Gestures
{
    class PinchRotate : GestureSequence
    {
        [Serializable]
        public class RotateEvent : UnityEvent<float, float, float> { }

        private const bool GRABBY_BEHAVIOUR = true;

        private readonly RotateEvent _rotateEvent;
        private readonly PinchCondition _pinch;
        
        public InternalState _state;
        private Vector3 _lastRot;
        public PinchRotate( HandModel handModel, RotateEvent rotateEvent ) : base(handModel)
        {
            _rotateEvent = rotateEvent;
            _pinch = new PinchCondition(handModel);
        }

        public override void Update()
        {
            _pinch.Update();
            var pinchTriggered = _pinch.Triggered;
            switch (_state)
            {
                case InternalState.Listening:
                    if (pinchTriggered)
                    {
                        _state = InternalState.Active;
                        _lastRot = HandModel.GetLeapHand().Rotation.Normalized.ToQuaternion().eulerAngles;
                    }
                    break;
                case InternalState.Active:
                    if (pinchTriggered)
                    {
                        _state = InternalState.Listening;
                    }
                    else
                    {
                        ActiveUpdate();
                    }
                    break;
            }
        }

        private void ActiveUpdate()
        {
            Vector3 newQ = HandModel.GetLeapHand().Rotation.Normalized.ToQuaternion().eulerAngles;
            Vector3 rot;
            if (GRABBY_BEHAVIOUR)
            {
                rot = newQ - _lastRot;
                _lastRot = newQ;
            }
            else
                rot = newQ;
            _rotateEvent.Invoke(rot.x, rot.y, rot.z);
        }

        public enum InternalState
        {
            Listening,
            Active
        }
    }
}
