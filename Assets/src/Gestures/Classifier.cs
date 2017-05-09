using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Leap;
using Leap.Unity;
// ReSharper disable UnusedMember.Local
#pragma warning disable 649

namespace Gestures
{
    /// <summary>
    /// The classifier was originally supposed to manage
    /// multiple gestures active in the same context.
    /// Instead, its functionality was changed to act
    /// more as a general gesture switcher and generic
    /// interface.
    /// </summary>
    class Classifier : MonoBehaviour
    {
        private readonly List<GestureSequence> _gestures = new List<GestureSequence>();

        [SerializeField] private HandModel _handModel;

        // Events for sequences
        [SerializeField] private RotateEvent _rotateEvent;
        [SerializeField] private PanEvent _panEvent;

        bool _buttonClicked = false;

        public bool IsActive
        {
            get { return _gestures.Any(g => g.State == GestureSeqState.Active); }
        }

        // Use this for initialization
        private void Start()
        {
            _gestures.Add(new PinchHoldRotate(_handModel, _rotateEvent));
        }


        // Update is called once per frame
        private void Update()
        {
            if (_buttonClicked)
            {
                foreach (var gs in _gestures)
                {
                    gs.Update();
                }
            }     
        }

        public void ActivatePinchGesture ()
        {
            if (_buttonClicked) _buttonClicked = false;
            else _buttonClicked = true;
        }


    }
}