using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

    protected bool rotateX = false;
    protected bool rotateY = false;
    protected bool rotateZ = false;

    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void CubeRotate(string axis)
    {
        if (axis == "x") { rotateX = !rotateX; rotateY = false; rotateZ = false; }
        else if (axis == "y") { rotateY = !rotateY; rotateX = false; rotateZ = false; }
        else if (axis == "z") { rotateZ = !rotateZ; rotateY = false; rotateX = false; }

        }

    public void Update()
    {
        if (rotateX) { transform.Rotate(new Vector3(0, 50, 50) * Time.deltaTime); Debug.Log("X axis"); rend.material.color = Color.blue; }
        else if (rotateY) { transform.Rotate(new Vector3(50, 0, 50) * Time.deltaTime); Debug.Log("Y axis"); rend.material.color = Color.red; }
        else if (rotateZ) { transform.Rotate(new Vector3(50, 50, 0) * Time.deltaTime); Debug.Log("Z axis"); rend.material.color = Color.yellow; }
        else { transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime); rend.material.color = Color.black; }
    }   
}
