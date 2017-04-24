using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
// ReSharper disable UnusedMember.Local
#pragma warning disable 649

namespace Gestures
{
    class Classifier : MonoBehaviour
    {
        private readonly List<GestureSequence> _gestures = new List<GestureSequence>();

        [SerializeField]
        private HandModel _handModel;

        // Events for sequences
        [SerializeField]
        private PinchRotate.RotateEvent _rotateEvent;


        // Use this for initialization
        private void Start()
        {
            _gestures.Add(new PinchRotate(_handModel, _rotateEvent));
        }

        // Update is called once per frame
        private void Update()
        {
            foreach (var gs in _gestures)
            {
                gs.Update();
            }
        }


    }
}