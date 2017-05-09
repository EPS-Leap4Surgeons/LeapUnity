using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Leap;
using System.Linq;

[System.Obsolete("This class is only around for reference. Do not use.")]
public class RotationDetect : MonoBehaviour {

    private const int QUEUE_SAMPLES = 100;

    private List<LeapQuaternion> Buffer = new List<LeapQuaternion>();

    public bool Active { get; private set; }

    public IHandModel HandModel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!Active)
            return;
        Debug.Log("Angle is " + GetRotationAngle());

	}

    private string GetRotationAngle()
    {
        
        Hand hand = HandModel.GetLeapHand();
        var rot = hand.Rotation;
        Buffer.RemoveAt(0);
        Buffer.Add(rot);
        rot = new LeapQuaternion(
            Buffer.Average(elem => elem.w),
            Buffer.Average(elem => elem.x),
            Buffer.Average(elem => elem.y),
            Buffer.Average(elem => elem.z));

        int decimals = 4;

        return Math.Round(rot.w, decimals) + " — " +
            Math.Round(rot.x, decimals) + " — " +
            Math.Round(rot.y, decimals) + " — " +
            Math.Round(rot.z, decimals);
    }

    public void TriggerGesture()
    {
        Active = !Active;
        if (Active)
        {
            FillBuffer();
        } else
        {
            Buffer.Clear();
        }
    }

    private void FillBuffer()
    {
        Hand hand = HandModel.GetLeapHand();
        var rot = hand.Rotation;
        for (int i = 0; i < QUEUE_SAMPLES; i++)
        {
            Buffer.Add(rot);
        }
    }
}
