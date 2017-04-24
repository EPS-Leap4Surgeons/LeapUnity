using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leap;
using Leap.Unity;


namespace Gestures
{
    /// <summary>
    /// GestureSequence is the core class at the heart of the
    /// gesture recognition functionality. It operates by 
    /// specifying a number of GestureConditions that must
    /// be performed, in sequence, in order to qualify as a
    /// gesture.
    /// </summary>
    abstract class GestureSequence
    {
        protected HandModel HandModel;

        protected GestureSequence(HandModel handModel)
        {
            HandModel = handModel;
        }

        public abstract void Update();
    }
}
