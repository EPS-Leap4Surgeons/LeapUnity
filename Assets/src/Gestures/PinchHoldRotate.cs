using Leap.Unity;
using UnityEngine;

namespace Gestures
{
    class PinchHoldRotate : GestureSequence
    {
        private const float ANCHOR_RANGE = 0.1f;
        private readonly RotateEvent _rotateEvent;
        private readonly PinchCondition _pinch;
        private Polar3 _lastRP;
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
                    _lastRP = new Polar3(curpos - _anchor);
                }
                State = GestureSeqState.Active;
                ActiveUpdate();
            }
            else
            {
                State = GestureSeqState.Listening;
            }
        }

        //private void OldActiveUpdate()
        //{
        //    var curpos = HandModel.GetIndexVector();
        //    var rp = curpos - _anchor;
        //    var rrp = rp - _lastRP;
        //    Debug.Log(rrp.ToString("F4"));
        //    _lastRP = rp;

        //    rrp = new Vector3((float)Math.Round(rrp.x,2), (float)Math.Round(rrp.y,2), (float)Math.Round(rrp.z,2));
        //    var x = rrp.x;
        //    var y = rrp.y;
        //    var z = rrp.z;
        //    var r = Math.Sqrt(x*x + y*y + z*z);
        //    //var Theta = Math.Acos(x/Math.Sqrt(x*x + y*y))*(y < 0 ? -1 : 1);
        //    //var Phi = Math.Acos(z/R);
        //    var theta = Math.Acos(z/r);
        //    var phi = Math.Atan(y/x);
            

        //    Debug.Log("Phi = " + phi + "     Theta = " + theta);

        //    _rotateEvent.Invoke((float)theta, (float)phi, 0);

        //}

        private void ActiveUpdate()
        {
            var curpos = HandModel.GetIndexVector();
            var rp = new Polar3(curpos - _anchor);
            var rrp = rp - _lastRP;
            _lastRP = rp;

            Debug.Log("rp: " + rp.ToString(3,1000) + "   rrp: " + rrp.ToString(3,100));

            var factor = 30;
            float theta = (float)rrp.Theta*factor;
            float phi = (float)rrp.Phi * factor;
            _rotateEvent.Invoke(-theta, -phi, 0);

        }
    }
}
