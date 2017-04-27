using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowModels : MonoBehaviour {


    LiverFunctions script;
    public GameObject canvas;
    public GameObject button;
    public Text nameLabel;
    float yPos = 75;
    int i = 1;

    public void Start()
    {
        getLiver();
    }

    private void getLiver()
    {
        canvas = GameObject.FindGameObjectWithTag("PanelShowModel");
        button = GameObject.FindGameObjectWithTag("btnBookmark");
        var liver = GameObject.FindGameObjectWithTag("Liver1");
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
        GameObject newButton = Instantiate(button, canvas.transform, false);
        yPos = yPos - 35;
        newButton.transform.localPosition = new Vector3(230, yPos, 0);
        i++;
        newButton.name = "btnBookmark" + i;
        newButton.GetComponentInChildren<Text>().text = "Bookmark " + i;

       
        // newButton.GetComponent<Text>().text = "Hi";



        /*SampleButton sampleButton = newButton.GetComponent<SampleButton>();
        sampleButton.Setup("bookmark2");*/
    }

    private class SampleButton : MonoBehaviour
    {
        public Button buttonComponent;
        public Text nameLabel;
        public Image iconImage;
        public Text priceText;

        // Use this for initialization
        void Start()
        {
            buttonComponent.onClick.AddListener(HandleClick);
        }

        public void Setup(string text)
        {
            nameLabel.text = text;
        }
        public void HandleClick()
        {
            //scrollList.TryTransferItemToOtherShop(item);
        }

    }
}
