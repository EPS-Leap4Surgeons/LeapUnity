using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {

    GameObject CanvasLiver;
    GameObject CanvasUI;

    // Use this for initialization
    void Start()
    {
        CanvasLiver = GameObject.FindGameObjectWithTag("CanvasLiver");
        CanvasUI = GameObject.FindGameObjectWithTag("CanvasUI");
    }

    public void closeCanvas()
    {
        bool isActive = CanvasLiver.activeSelf;
        CanvasLiver.SetActive(!isActive);
        CanvasUI.SetActive(isActive);
    }
}
