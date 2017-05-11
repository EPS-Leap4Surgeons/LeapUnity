using Leap.Unity;

namespace Gestures
{
    /// <summary>
    /// The original idea here was to have a second
    /// condition that would detect when you're
    /// holding your hand in a fist. This would
    /// allow one to rotate using a pinch, and pan
    /// using a fist, for example. Since concurrent
    /// gestures were eventually decided against,
    /// and all gestures would trigger with just
    /// the pinch condition, we simply remapped the
    /// fist condition to the pinch condition. If
    /// you ever feel like having concurrent
    /// gestures again, one needs only to properly
    /// implement this class.
    /// </summary>
    internal class FistCondition : PinchCondition
    {
        public FistCondition(HandModel handModel, bool oneShot = true) : base(handModel, oneShot)
        {
        }
    }
}