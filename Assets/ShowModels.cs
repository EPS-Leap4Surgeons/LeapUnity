using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModels : MonoBehaviour {


    LiverFunctions script;

    public void Start()
    {
        getLiver();
    }

    private void getLiver()
    {
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
}
