using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leap.Unity;


namespace Gestures
{
    /// <summary>
    /// GestureCondition is a simple class that describes
    /// the state in which a hand can be. If a HandModel qualifies
    /// a condition, a GestureSequence can be advanced by one
    /// step. A completed GestureSequence triggers a
    /// GestureEvent.
    /// </summary>
    abstract class GestureCondition
    {
        protected readonly HandModel HandModel;
        private bool _debounce;
        private bool _triggered;

        // Triggered can use a debounce. It will only return true
        // once per being triggered. It has to be set to false at
        // least once in order to return true again. To activate
        // this behaviour, set BehaveLikeOneShot to true.
        public bool Triggered
        {
            get
            {
                var retval = _triggered;
                if (BehaveLikeOneShot)
                    _triggered = false;
                return retval;
            }
            protected set
            {
                _triggered = _debounce ? _triggered : value;
                _debounce = value;
            }
        }

        protected abstract bool BehaveLikeOneShot { get; }

        protected GestureCondition(HandModel handModel)
        {
            HandModel = handModel;
        }

        public abstract void Update();
    }
}