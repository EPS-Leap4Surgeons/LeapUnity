using Leap.Unity;
using UnityEngine;

namespace Gestures
{
    class PinchHoldRotate : GestureSequence
    {
        private const float ANCHOR_RANGE = 0.1f;
        private readonly RotateEvent _rotateEvent;
        private readonly PinchCondition _pinch;
        private Polar3 _lastRp;
        private Vector3 _anchor;

        public PinchHoldRotate(HandModel handModel, RotateEvent rotateEvent)
            : base(handModel)
        {
            _rotateEvent = rotateEvent;
            _pinch = new PinchCondition(handModel, false);
        }


        public override void Update()
        {
            _pinch.Update();
            var pinchTriggered = _pinch.Triggered;
            if (pinchTriggered)
            {
                if (State == GestureSeqState.Listening)
                {
                    var curpos = HandModel.GetIndexVector();
                    _anchor = curpos + new Vector3(0, 0, ANCHOR_RANGE);
                    _lastRp = new Polar3(curpos - _anchor);
                }
                State = GestureSeqState.Active;
                ActiveUpdate();
            }
            else
            {
                State = GestureSeqState.Listening;
            }
        }

        private void ActiveUpdate()
        {
            var curpos = HandModel.GetIndexVector();
            var rp = new Polar3(curpos - _anchor);
            var rrp = rp - _lastRp;
            _lastRp = rp;

            //Debug.Log("rp: " + rp.ToString(3,1000) + "   rrp: " + rrp.ToString(3,100));

            var factor = 50;
            float theta = (float)rrp.Theta*factor;
            float phi = (float)rrp.Phi * factor;
            _rotateEvent.Invoke(-theta, -phi, 0);

        }
    }
}
