using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {

    GameObject PanelModel;
    GameObject PanelMainMenu;

    // Use this for initialization
    void Start ()
    {
        PanelModel = GameObject.FindGameObjectWithTag("PanelModel");
        PanelMainMenu = GameObject.FindGameObjectWithTag("PanelMainMenu");
        PanelMainMenu.SetActive(false);
    }
	
	public void openMainMenu ()
    {
        bool isActive = PanelMainMenu.activeSelf;
        PanelMainMenu.SetActive(!isActive);
        PanelModel.SetActive(isActive);
        
    }

    
}
