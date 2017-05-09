using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {

    GameObject PanelModel;
    GameObject PanelMainMenu;

    // Use this for initialization
    void Start()
    {
        PanelModel = GameObject.FindGameObjectWithTag("PanelModel");
        PanelMainMenu = GameObject.FindGameObjectWithTag("PanelMainMenu");   
    }

    public void closePanels()
    {
        //bool isActive = PanelMainMenu.activeSelf;
        
        PanelMainMenu.SetActive(false);
        PanelModel.SetActive(true);
        
        Debug.Log(PanelModel.activeSelf);
        Debug.Log("here");
    }
}
