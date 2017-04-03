using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

namespace Gestures
{
    public class Classifier : MonoBehaviour
    {

        IController Controller;

        List<GestureSequence> Gestures = new List<GestureSequence>();


        // Use this for initialization
        void Start()
        {
            Gestures.Add(new PinchGestureSequence());

        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}