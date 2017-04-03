using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// GestureCondition is a simple class that describes
/// the state in which a hand can be. If a hand qualifies
/// a condition, a GestureSequence can be advanced by one
/// step. A completed GestureSequence triggers a
/// GestureEvent.
/// </summary>

namespace Gestures
{
    abstract class GestureCondition
    {
        abstract internal bool TestCondition(Leap.Frame frame);

    }
}
