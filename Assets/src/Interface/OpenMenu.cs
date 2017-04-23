using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {

    GameObject CanvasUI;
    GameObject CanvasLiver;

    // Use this for initialization
    void Start () {
        CanvasUI = GameObject.FindGameObjectWithTag("CanvasUI");
        CanvasLiver = GameObject.FindGameObjectWithTag("CanvasLiver");
        CanvasUI.SetActive(false);
    }
	
	public void openCanvas ()
    {
        bool isActive = CanvasUI.activeSelf;
        CanvasUI.SetActive(!isActive);
        CanvasLiver.SetActive(isActive);
    }
}
