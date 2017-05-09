using System;
using Leap;
using Leap.Unity;
using UnityEngine;

namespace Gestures
{
    class PinchCondition : GestureCondition
    {
        private const float PINCH_DISTANCE = 20f;
        private const float DEBOUNCE_FACTOR = 2f;
        
        public PinchCondition(HandModel handModel, bool oneShot = true)
            : base(handModel)
        {
            BehaveLikeOneShot = oneShot;
        }

        public override void Update()
        {
            var hand = HandModel.GetLeapHand();
            if (hand == null)
            {
                Triggered = false;
                return;
            }
            if (hand.PinchDistance < PINCH_DISTANCE - DEBOUNCE_FACTOR)
            {
                Triggered = true;
            }
            else if (hand.PinchDistance > PINCH_DISTANCE + DEBOUNCE_FACTOR)
            {
                Triggered = false;
            }
        }
    }
}
