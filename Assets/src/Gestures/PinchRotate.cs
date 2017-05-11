using System;
using UnityEngine.Events;
using Leap.Unity;
using UnityEngine;

namespace Gestures
{
    /// This is the first gesture we implemented.It operates as
    /// follows:
    ///    - Pinch once to activate.
    ///    - Rotate your hand freely, the model rotates similarly.
    ///    - Pinch again to deactivate.
    /// The particular thing about this gesture is that you do not
    /// need to keep pinching in order for it to stay activated.
    /// You can pinch, relax your hand, rotate it, and pinch again
    /// to deativate. This is mostly kept around to demonstrate
    /// the possibility to use gestures this way.In order to do
    /// this, you have to pass on 'oneShot: false' when creating
    /// the PinchCondition, as you can see in the constructor here.
    /// 
    /// <summary>
    /// Demo gesture, kept around for reference purposes.
    /// </summary>
    [System.Obsolete("This class is deprecated. Use as a reference ONLY.", true)]
    class PinchRotate : GestureSequence
    {
        private readonly RotateEvent _rotateEvent;
        private readonly PinchCondition _pinch;
        private Vector3 _lastRot;

        public PinchRotate( HandModel handModel, RotateEvent rotateEvent )
            : base(handModel)
        {
            _rotateEvent = rotateEvent;
            _pinch = new PinchCondition(handModel, oneShot: false);
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
