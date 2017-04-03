﻿using UnityEngine;

public enum LiverPart
{
    Parenchy,
    Hepatic,
    Portal,
    Tumor
}



public class LiverFunctions : MonoBehaviour {

    protected bool rotateX = false;
    protected bool rotateY = false;
    protected bool rotateZ = false;

    private int xValue = 50;
    private int yValue = 50;
    private int zValue = 50;
    private int tempValue = 10;
    private int tempDifference;

    float newValue;

    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    private GameObject GetGameObject( LiverPart part )
    {
        switch( part )
        {
            case LiverPart.Hepatic:
                return GameObject.FindGameObjectWithTag("HepaticModel");
            case LiverPart.Parenchy:
                return GameObject.FindGameObjectWithTag("ParenchyModel");
            case LiverPart.Portal:
                return GameObject.FindGameObjectWithTag("PortalModel");
            case LiverPart.Tumor:
                return GameObject.FindGameObjectWithTag("TumorModel");
        }
        return GameObject.FindGameObjectWithTag("TumorModel");
    }

    public bool SwitchVisibility( LiverPart part)
    {
        var GOpart = GetGameObject(part);
        Debug.Log("Just hit " + part.ToString());
        if (GOpart == null)
            Debug.Log("We're hitting null");
        bool isActive = GOpart.activeSelf;
        GOpart.SetActive(!isActive);
        return !isActive;
    }

    public void LiverRotate(string axis)
    {
        Debug.Log("Rotate funtion");
        if (axis == "x") { rotateX = !rotateX; rotateY = false; rotateZ = false; }
        else if (axis == "y") { rotateY = !rotateY; rotateX = false; rotateZ = false; }
        else if (axis == "z") { rotateZ = !rotateZ; rotateY = false; rotateX = false; }

    }

    public void ShowModels (string model)
    {
        if (model == "panerchy") GameObject.FindGameObjectWithTag("ParenchyModel").SetActive(true);
        else if (model == "notPanerchy") GameObject.FindGameObjectWithTag("ParenchyModel").SetActive(false);

    }

    public void Slider_changed (float newValue)
    {
        Debug.Log("slider:" + rotateX);
        if (rotateX)
        {
            yValue = (int)newValue;
            zValue = (int)newValue;
        }
        else if (rotateY)
        {
            xValue = (int)newValue;
            zValue = (int)newValue;
        }
        else if (rotateZ)
        {
            yValue = (int)newValue;
            xValue = (int)newValue;
        }
    }
    public void rotateXYZ(float x, float y, float z)
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }

    public void Update()
    {
        if (rotateX) { transform.Rotate(new Vector3(0, yValue, zValue) * Time.deltaTime); Debug.Log("X axis"); Debug.Log("yValue:" + yValue); Debug.Log("zValue:" + zValue); }
        else if (rotateY) { transform.Rotate(new Vector3(xValue, 0, zValue) * Time.deltaTime); Debug.Log("Y axis"); }
        else if (rotateZ) { transform.Rotate(new Vector3(xValue, yValue, 0) * Time.deltaTime); Debug.Log("Z axis"); }
        else { transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime); }

        
    }   
}
