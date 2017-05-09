using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour {

    GameObject liver;
    GameObject teddy;

    // Use this for initialization
    void Start () {
        liver = GameObject.FindGameObjectWithTag("Liver1");
        teddy = GameObject.FindGameObjectWithTag("TeddyModel");

    }
	
	// Update is called once per frame
	void Update () {

        teddy.transform.rotation = Quaternion.identity;
        teddy.transform.Rotate(new Vector3(liver.transform.localEulerAngles.x, liver.transform.localEulerAngles.y, liver.transform.localEulerAngles.z));

    }
}
