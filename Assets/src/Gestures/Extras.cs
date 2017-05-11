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

    /// <summary>
    /// The available gesture-backed tools.
    /// </summary>
    public enum Tool
    {
        Rotation = 1,
        Panning = 2,
        Zooming = 3,
        /// <summary>Not per se a tool, rather the absence of one.</summary>
        Disabled = 0
    }

    /// <summary>
    /// Function that calls the model's RotateXYZ function. Performs an
    /// incremental rotation by respectively X, Y, and Z degrees.
    /// </summary>
    [Serializable]
    public class RotateEvent : UnityEvent<float, float, float> { }

    /// <summary>
    /// Function that calls the model's TranslateXYZ function. Performs an
    /// incremental movement by respectively X, Y, and Z units in their 
    /// respective directions.
    /// </summary>
    [Serializable]
    public class PanEvent : UnityEvent<float, float, float> { }

    /// <summary>
    /// A few extension methods (look it up) to reduce code clutter elsewhere.
    /// </summary>
    static class Extensions
    {
        /// <summary>
        /// Shortcut to get the TipPosition of the index finger of this hand.
        /// </summary>
        /// <returns>The Vector3 representing the
        /// position of the index finger's tip.</returns>
        internal static Vector3 GetIndexVector(this HandModel handModel)
        {
            // To how many decimals after the comma the coordinates get rounded
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

    /// <summary>
    /// Represents a spacial 3D position not in the Cartesian, but in the
    /// Polar Coordinate system. This is a coordinate system that expresses
    /// position in relative angles and as such is very useful in functions
    /// that deal with rotations.
    /// </summary>
    struct Polar3
    {
        /// <summary>
        /// The original Vector3 with Cartesian coordinates,
        /// from which this Polar3 was constructed.
        /// </summary>
        public readonly Vector3 OrigVec;
        /// <summary>Distance to origin.</summary>
        public readonly double R;
        /// <summary>
        /// In the XZ-plane, angle between the point,
        /// origin, and the positive X-axis.
        /// </summary>
        public readonly double Phi;
        /// <summary>Angle between the point, origin, and the positive Y-axis.</summary>
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

        // For now the only operator is the minus, because that's the only
        // one we've needed for now.
        public static Polar3 operator -(Polar3 a, Polar3 b)
        {
            return new
                Polar3(a.R - b.R, a.Phi - b.Phi, a.Theta - b.Theta);
        }

        /// <summary>
        /// Basic ToString method. Use the overloaded method for clearer output.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(4, anglesDeg: false);
        }

        /// <summary>
        /// Enhanced ToString for debug purposes.
        /// </summary>
        /// <param name="decimals">To how many decimals output should be rounded.</param>
        /// <param name="rMult">Factor by which R should be multiplied,
        /// handy if it's consistently tenths or hundredths you're dealing with.</param>
        /// <param name="anglesDeg">Show angles in degrees instead of radians.</param>
        /// <param name="showOrig">Print the original Cartesian Vector3 from which
        /// this Polar3 was created.</param>
        /// <returns>A useful, formatted debug string.</returns>
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
