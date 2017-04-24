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
        
        // We set this to true, because we're only interested
        // in one pinch trigger per "pinch gesture".
        protected override bool BehaveLikeOneShot { get { return true; } }

        public PinchCondition(HandModel handModel) : base(handModel) { }

        public override void Update()
        {
            var hand = HandModel.GetLeapHand();
            if (hand == null)
                return;
            
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
