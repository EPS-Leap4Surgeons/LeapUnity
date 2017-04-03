using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRotate : MonoBehaviour
{
    public Button button;
    string x,y,z;
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

    public void RotateX()
    {
        x = "x";;
        script.LiverRotate(x);
    }

    public void RotateY()
    {
        y = "y";
        script.LiverRotate(y);
    }

    public void RotateZ()
    {
        z = "z";
        script.LiverRotate(z);
    }
}



