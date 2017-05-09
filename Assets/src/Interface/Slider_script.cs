using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_script : MonoBehaviour {

    float newValue2 = 25;

    public void Start()
    {

    }

    public void Sliding(float newValue)
    {
        newValue2 = newValue / 10;
    }

    private void Update()
    {
        Camera.main.fieldOfView = newValue2;
    }
}
