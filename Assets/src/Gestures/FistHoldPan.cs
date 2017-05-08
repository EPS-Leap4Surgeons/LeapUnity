using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leap.Unity;
using UnityEngine;

namespace Gestures
{
    class FistHoldPan : GestureSequence
    {
        private const float PAN_SPEED = 1.5f;
        private readonly PanEvent _panEvent;
        private readonly FistCondition _fist;
        private Vector3 _lastPos;

        public FistHoldPan(HandModel handModel, PanEvent panEvent) : base(handModel)
        {
            _panEvent = panEvent;
            _fist = new FistCondition(handModel, false);
        }

        public override void Update()
        {
            _fist.Update();
            if (_fist.Triggered)
            {
                if (State == GestureSeqState.Listening)
                    _lastPos = HandModel.GetIndexVector();
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
            var newPos = HandModel.GetIndexVector();
            var pan = newPos - _lastPos;
            _lastPos = newPos;
            _panEvent.Invoke(pan.x * PAN_SPEED, pan.y * PAN_SPEED, 0);
        }
    }
}
