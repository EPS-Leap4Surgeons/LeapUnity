using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

    protected bool rotate = false;

    public void CubeRotate()
    {
        rotate = !rotate;
    }

    public void Update()
    {
        
        if (rotate)
        {
            transform.Rotate(new Vector3(150, 300, 60) * Time.deltaTime);
        }
    }   

    // Update is called once per frame
    /*void Update () {
        transform.Rotate(new Vector3(0, 0, 20) * Time.deltaTime);
	}*/
}
