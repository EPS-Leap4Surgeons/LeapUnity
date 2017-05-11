using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour {

    GameObject rotate;
    GameObject pan;
    GameObject zoom;

    Color colorGesture = Color.white;
    Color colorPan = Color.white;
    Color colorZoom = Color.white;
    private void Start()
    {
        rotate = GameObject.FindGameObjectWithTag("btnRotate");
        pan = GameObject.FindGameObjectWithTag("btnPan");
        zoom = GameObject.FindGameObjectWithTag("btnZoom");
    }
    public void ChangeColorbtnRotate ()
    {
        if (colorGesture == Color.green)
            colorGesture = Color.white;
        else
        {
            colorGesture = Color.green;
            colorPan = Color.white;
            colorZoom = Color.white;
        }
        change();
    }

    public void ChangeColorbtnPan()
    {
        if (colorPan == Color.green)
            colorPan = Color.white;
        else
        {
            colorPan = Color.green;
            colorGesture = Color.white;
            colorZoom = Color.white;
        }
        change();
    }

    public void ChangeColorbtnZoom()
    {
        if (colorZoom == Color.green)
            colorZoom = Color.white;
        else
        {
            colorZoom = Color.green;
            colorGesture = Color.white;
            colorPan = Color.white;
        }
        change();
    }

    private void change()
    {
        zoom.GetComponent<Image>().color = colorZoom;
        pan.GetComponent<Image>().color = colorPan;
        rotate.GetComponent<Image>().color = colorGesture;
    }
}
