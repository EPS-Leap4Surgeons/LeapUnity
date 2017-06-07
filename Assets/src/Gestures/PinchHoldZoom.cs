using Leap.Unity;
using UnityEngine;

namespace Gestures
{

	class PinchHoldZoom : GestureSequence
	{
		private const float ANCHOR_RANGE = 0.1f;
		private readonly ZoomEvent _zoomEvent;
		private readonly PinchCondition _pinch;
		private Polar3 _lastRp;
		private Vector3 _anchor;

		public PinchHoldZoom(HandModel handModel, ZoomEvent zoomEvent)
			: base(handModel)
		{
			_zoomEvent = zoomEvent;
			_pinch = new PinchCondition(handModel, false);
		}


		public override void Update()
		{
			_pinch.Update();
			var pinchTriggered = _pinch.Triggered;
			if (pinchTriggered)
			{
				if (State == GestureSeqState.Listening)
				{
					var curpos = HandModel.GetIndexVector();
					_anchor = curpos + new Vector3(0, 0, ANCHOR_RANGE);
					_lastRp = new Polar3(curpos - _anchor);
				}
				State = GestureSeqState.Active;
				ActiveUpdate();
			}
			else
			{
				State = GestureSeqState.Listening;
			}
		}

		private void ActiveUpdate()
		{
			var curpos = HandModel.GetIndexVector();
			var rp = new Polar3(curpos - _anchor);		// rp  = relative position
			var rrp = rp - _lastRp;						// rrp = relative relative position
			_lastRp = rp;

			var factor = -150f;
			_zoomEvent.Invoke((float)rrp.R * factor);

		}
	}
}
