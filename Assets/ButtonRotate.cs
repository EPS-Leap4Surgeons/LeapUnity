using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRotate : MonoBehaviour
{
    public Button button;
    string x,y,z;

    public void Button_Click()
    {
        //Rotate();
    }

    public void RotateX()
    {
        x = "x";
        var cube = GameObject.FindGameObjectWithTag("cube1");
        RotateCube script = (RotateCube) cube.GetComponent(typeof(RotateCube));
        script.CubeRotate(x);
    }

    public void RotateY()
    {
        y = "y";
        var cube = GameObject.FindGameObjectWithTag("cube1");
        RotateCube script = (RotateCube)cube.GetComponent(typeof(RotateCube));
        script.CubeRotate(y);
    }

    public void RotateZ()
    {
        z = "z";
        var cube = GameObject.FindGameObjectWithTag("cube1");
        RotateCube script = (RotateCube)cube.GetComponent(typeof(RotateCube));
        script.CubeRotate(z);
    }
}



