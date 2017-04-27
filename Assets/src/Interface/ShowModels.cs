using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShowModels : MonoBehaviour {


    LiverFunctions script;
    public GameObject canvas;
    public GameObject button;
    public Text nameLabel;
    float yPos = 110;
    int i = 0;
    GameObject liver;
    double[,] bookmarkArray = new double[10, 7];

    public void Start()
    {
        getLiver();
        button.GetComponent<Button>().onClick.AddListener(NewButton);

    }

    private void getLiver()
    {
        canvas = GameObject.FindGameObjectWithTag("PanelShowModel");
        button = GameObject.FindGameObjectWithTag("btnBookmark");
        liver = GameObject.FindGameObjectWithTag("Liver1");       
        script = (LiverFunctions)liver.GetComponent(typeof(LiverFunctions));
    }

    public void Show_Parenchy(bool parenchy)
    {
        bool isActive = script.SwitchVisibility(LiverPart.Parenchy);
    }

    public void Show_Hepatic(bool hepatic)
    {
        bool isActive = script.SwitchVisibility(LiverPart.Hepatic);
    }

    public void Show_Portal(bool portal)
    {
        bool isActive = script.SwitchVisibility(LiverPart.Portal);
    }

    public void Show_Tumor(bool tumor)
    {
        bool isActive = script.SwitchVisibility(LiverPart.Tumor);
    }

    public void NewButton ()
    {
        i++;

        if (i < 5)
        {
            GameObject newButton = Instantiate(button, canvas.transform, false);
            newButton.GetComponent<Button>().onClick.RemoveAllListeners();
            newButton.GetComponent<Button>().onClick.AddListener(bookmark_position);
            newButton.name = "btnBookmark" + i;
            newButton.GetComponentInChildren<Text>().text = "Bookmark " + i;

            yPos = yPos - 35;
            newButton.transform.localPosition = new Vector3(230, yPos, 0);
            bookmarkArray[i - 1, 0] = i; 
        }     
    }

    public void bookmark_position ()
    {
        string tempName = EventSystem.current.currentSelectedGameObject.name;
        int buttonNumber = Convert.ToInt32(tempName[tempName.Length - 1]) - 48;

        for (int o = 0; o < bookmarkArray.GetLength(0); o++)
        {            
            if (buttonNumber == bookmarkArray[o, 0])
            {
                if (bookmarkArray[o, 1] == 0)
                {
                    Debug.Log("Set array");
                    bookmarkArray[o, 1] = liver.transform.position.x;
                    bookmarkArray[o, 2] = liver.transform.position.y;
                    bookmarkArray[o, 3] = liver.transform.position.z;
                    bookmarkArray[o, 4] = liver.transform.localEulerAngles.x;
                    bookmarkArray[o, 5] = liver.transform.localEulerAngles.y;
                    bookmarkArray[o, 6] = liver.transform.localEulerAngles.z;
                }
                else
                {            
                    Debug.Log("get Array");
                    liver.transform.rotation = Quaternion.identity;
                    liver.transform.position = new Vector3((float)bookmarkArray[o, 1], (float)bookmarkArray[o, 2], (float)bookmarkArray[o, 3]);
                    liver.transform.Rotate(new Vector3((float)bookmarkArray[o, 4], (float)bookmarkArray[o, 5], (float)bookmarkArray[o, 6]));
                }     
            }
        } 

    }
}
