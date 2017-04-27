using System;
using UnityEngine.Events;
using Leap.Unity;
using UnityEngine;

namespace Gestures
{
    class PinchRotate : GestureSequence
    {
        private readonly RotateEvent _rotateEvent;
        private readonly PinchCondition _pinch;
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
            switch (State)
            {
                case GestureSeqState.Listening:
                    if (pinchTriggered)
                    {
                        State = GestureSeqState.Active;
                        _lastRot = HandModel.GetLeapHand().Rotation.Normalized.ToQuaternion().eulerAngles;
                    }
                    break;
                case GestureSeqState.Active:
                    if (pinchTriggered)
                    {
                        State = GestureSeqState.Listening;
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
            Vector3 rot = newQ - _lastRot;
            _lastRot = newQ;
            _rotateEvent.Invoke(rot.x, rot.y, rot.z);
        }
    }
}
