using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {

    GameObject PanelSlider;
    GameObject PanelShowModel;
    GameObject PanelMainMenu;
    GameObject PanelLockAxis;

    // Use this for initialization
    void Start()
    {
        PanelShowModel = GameObject.FindGameObjectWithTag("PanelShowModel");
        PanelSlider = GameObject.FindGameObjectWithTag("PanelSlider");
        PanelMainMenu = GameObject.FindGameObjectWithTag("PanelMainMenu");
        PanelLockAxis = GameObject.FindGameObjectWithTag("PanelLockAxis");
        
    }

    public void closePanels()
    {
        bool isActive = PanelMainMenu.activeSelf;
        PanelMainMenu.SetActive(!isActive);
        PanelSlider.SetActive(isActive);
        PanelShowModel.SetActive(isActive);
        PanelLockAxis.SetActive(isActive);
    }
}
