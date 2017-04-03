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
        
        if (hepatic)
            script.ShowModels("hepatic");
    }

    public void Show_Portal(bool portal)
    {
        
        if (portal)
            script.ShowModels("portal");
    }

    public void Show_Tumor(bool tumor)
    {
        
        if (tumor)
            script.ShowModels("tumor");
    }
}
