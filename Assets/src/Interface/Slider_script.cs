using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_script : MonoBehaviour {

    LiverFunctions script;

    public void Start()
    {
        getLiver();
    }

    private void getLiver()
    {
        var liver = GameObject.FindGameObjectWithTag("Liver1");
        script = (LiverFunctions)liver.GetComponent(typeof(LiverFunctions));
    }

    public void Sliding(float newValue)
    {
        script.Slider_changed(newValue);

    }
}
