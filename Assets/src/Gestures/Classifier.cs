using System;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
// ReSharper disable UnusedMember.Local
#pragma warning disable 649

namespace Gestures
{
    /// The classifier was originally supposed to manage
    /// multiple gestures active in the same context.
    /// Instead, its functionality was changed to act
    /// more as a general gesture switcher and generic
    /// interface.
    /// 
    /// <summary>
    /// Basically the gesture switcher.
    /// </summary>
    class Classifier : MonoBehaviour
    {
        private readonly List<GestureSequence> _gestures = new List<GestureSequence>();
        private GestureSequence _activeGestureSequence;

        // Use SerializeField so that we can attach the
        // HandModel in the Unity Editor's interface
        [SerializeField] private HandModel _handModel;

        // Events for sequences
        [SerializeField] private RotateEvent _rotateEvent;
        [SerializeField] private PanEvent _panEvent;
	    [SerializeField] private ZoomEvent _zoomEvent;

        public bool IsActive
        {
            get { return _activeGestureSequence != null
                    && _activeGestureSequence.State == GestureSeqState.Active; }
        }
        
        private void Start()
        {
            _gestures.Add(new FistHoldPan(_handModel, _panEvent));
            _gestures.Add(new PinchHoldRotate(_handModel, _rotateEvent));
			_gestures.Add(new PinchHoldZoom(_handModel, _zoomEvent));
        }

        public void ChangeTool(int tool)
        {
			Tool etool = (Tool)tool;
            Type newGesture;
            switch (etool)
            {
                case Tool.Panning:
                    newGesture = typeof(FistHoldPan);
                    break;
                case Tool.Rotation:
                    newGesture = typeof(PinchHoldRotate);
                    break;
				case Tool.Zooming:
					newGesture = typeof(PinchHoldZoom);
					break;
                default:
                    newGesture = null;
                    break;
            }
			if (_activeGestureSequence != null && _activeGestureSequence.GetType() == newGesture)
				newGesture = null;

            _activeGestureSequence = _gestures.Find(g => g.GetType() == newGesture);
        }

        // Update is called once per frame
        private void Update()
        {
			if (_activeGestureSequence != null)
	            _activeGestureSequence.Update();  
        }
    }
}