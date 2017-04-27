using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {

    GameObject PanelSlider;
    GameObject PanelShowModel;
    GameObject PanelMainMenu;
    GameObject PanelLockAxis;

    // Use this for initialization
    void Start () {
        PanelShowModel = GameObject.FindGameObjectWithTag("PanelShowModel");
        PanelSlider = GameObject.FindGameObjectWithTag("PanelSlider");
        PanelMainMenu = GameObject.FindGameObjectWithTag("PanelMainMenu");
        PanelLockAxis = GameObject.FindGameObjectWithTag("PanelLockAxis");
        PanelLockAxis.SetActive(false);
        PanelSlider.SetActive(false);
        PanelShowModel.SetActive(false);

    }
	
	public void openPanelShowmodel ()
    {
        bool isActive = PanelMainMenu.activeSelf;
        PanelMainMenu.SetActive(!isActive);
        PanelShowModel.SetActive(isActive);
    }

    public void openPanelSlider()
    {
        bool isActive = PanelMainMenu.activeSelf;
        PanelMainMenu.SetActive(!isActive);
        PanelSlider.SetActive(isActive);
    }

    public void openPanelLockAxis()
    {
        bool isActive = PanelMainMenu.activeSelf;
        PanelMainMenu.SetActive(!isActive);
        PanelLockAxis.SetActive(isActive);
    }
}
