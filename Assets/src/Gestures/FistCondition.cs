using Leap.Unity;

namespace Gestures
{
    internal class FistCondition : PinchCondition
    {
        public FistCondition(HandModel handModel, bool oneShot = true) : base(handModel, oneShot)
        {
        }
    }
}