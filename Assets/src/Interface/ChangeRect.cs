using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRect : MonoBehaviour {

    public void ChangeViewportRect()
    {
        Camera.main.rect = new Rect((float)0.02, (float)0.02, (float)0.30, (float)0.30);
    }

    public void ChangeViewportRectModel()
    {
        Camera.main.rect = new Rect((float)0.16, (float)0.16, (float)0.65, (float)0.65);
    }
}
