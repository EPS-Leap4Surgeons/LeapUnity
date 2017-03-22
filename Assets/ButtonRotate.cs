using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRotate : MonoBehaviour
{
    public Button button;

    public void Button_Click()
    {
        Rotate();
    }

    void Rotate()
    {
        var cube = GameObject.FindGameObjectWithTag("cube1");
        RotateCube script = (RotateCube) cube.GetComponent(typeof(RotateCube));
        script.CubeRotate();
    }
}
