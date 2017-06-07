using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour {

    [SerializeField] public GameObject liver;
    private GameObject teddy;
	private Vector3 modelOffset;
	private readonly Vector3 teddyOffsetv = new Vector3(0, 200, -3);



    // Use this for initialization
    void Start () {
		modelOffset = new Vector3(-100, -25, 0);  // TODO: implement reading this from metadata
        teddy = GameObject.FindGameObjectWithTag("TeddyModel");
    }
	
	// Update is called once per frame
	void Update () {

		//teddy.transform.rotation = Quaternion.identity;
		//teddy.transform.Rotate(new Vector3(liver.transform.localEulerAngles.x, liver.transform.localEulerAngles.y, liver.transform.localEulerAngles.z));
		var livertransform = liver.transform.localEulerAngles;
		Debug.Log(livertransform);
		teddy.transform.localEulerAngles = new Vector3(livertransform.x + 100, livertransform.y + 25, livertransform.z);
    }
}
