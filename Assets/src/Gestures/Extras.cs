using System;
using Leap;
using Leap.Unity;
using UnityEngine;
using UnityEngine.Events;

namespace Gestures
{
    public enum GestureSeqState
    {
        Listening,
        Active
    }

    [Serializable]
    public class RotateEvent : UnityEvent<float, float, float> { }

    [Serializable]
    public class PanEvent : UnityEvent<float, float, float> { }

    static class Extensions
    {
        internal static Vector3 GetIndexVector(this HandModel handModel)
        {
            int ACCURACY = 4;

            var tip = handModel.GetLeapHand().Fingers
                .Find(f => f.Type == Finger.FingerType.TYPE_INDEX)
                .TipPosition;

            //uncomment to disable rounding
            //return tip.ToVector3();

            return new Vector3((float)Math.Round(tip.x, ACCURACY),
                               (float)Math.Round(tip.y, ACCURACY),
                               (float)Math.Round(tip.z, ACCURACY));
        }
    }

    struct Polar3
    {
        public readonly Vector3 OrigVec;
        public readonly double R;
        public readonly double Phi;
        public readonly double Theta;

        public Polar3(Vector3 origVec)
        {
            OrigVec = origVec;
            var x = origVec.x;
            var y = origVec.z;
            var z = origVec.y;
            R = Math.Sqrt(x*x + y*y + z*z);
            Theta = Math.Acos(z/R);
            Phi = Math.Atan2(y,x);
            Phi = double.IsNaN(Phi) ? 0 : Phi;
            Theta = double.IsNaN(Theta) ? 0 : Theta;
        }

        private Polar3(double r, double phi, double theta)
        {
            R = double.IsNaN(r) ? 0 : r;
            Phi = double.IsNaN(phi) ? 0 : phi;
            Theta = double.IsNaN(theta) ? 0 : theta;
            OrigVec = new Vector3(float.NaN, float.NaN, float.NaN);
        }

        public static Polar3 operator -(Polar3 a, Polar3 b)
        {
            return new
                Polar3(a.R - b.R, a.Phi - b.Phi, a.Theta - b.Theta);
        }

        public override string ToString()
        {
            return ToString(2);
            //return "{r=" + R + "; Phi=" + Phi + "; Theta=" + Theta;
        }

        public string ToString(int decimals, int rMult = 1, bool anglesDeg = true, bool showOrig = false)
        {
            var r = Math.Round(R*rMult, decimals);
            var phi = Math.Round(anglesDeg
                ? Phi*(180.0/Math.PI)
                : Phi, decimals);
            var theta = Math.Round(anglesDeg
                ? Theta*(180.0/Math.PI)
                : Theta, decimals);

            return "{r=" + r + "; Phi=" + phi + "; Theta=" + theta +
                (showOrig ? "; origv=" + OrigVec.ToString("F3") : "") + "}";
        }
    }
}
