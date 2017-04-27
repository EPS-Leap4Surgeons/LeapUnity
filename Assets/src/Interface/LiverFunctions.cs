using UnityEngine;

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

    GameObject liver;
    GameObject Hepatic;
    GameObject Parenchy;
    GameObject Portal;
    GameObject Tumor;

    float newValue;

    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        liver = GameObject.FindGameObjectWithTag("Liver1");
        Hepatic = GameObject.FindGameObjectWithTag("HepaticModel");  
        Parenchy = GameObject.FindGameObjectWithTag("ParenchyModel");
        Portal = GameObject.FindGameObjectWithTag("PortalModel");
        Tumor = GameObject.FindGameObjectWithTag("TumorModel");

        Transform liverTransform = liver.transform;
        Debug.Log(liverTransform.position.x);
    }

    private GameObject GetGameObject( LiverPart part )
    {
        switch( part )
        {
            case LiverPart.Hepatic:
                return Hepatic;
            case LiverPart.Parenchy:
                return Parenchy;
            case LiverPart.Portal:
                return Portal;
            case LiverPart.Tumor:
                return Tumor;
        }
        return Tumor;
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
        transform.Rotate(new Vector3(x, y, z), Space.World);
    }

    public void Update()
    {
        if (rotateX) { transform.Rotate(new Vector3(0, yValue, zValue) * Time.deltaTime); }
        else if (rotateY) { transform.Rotate(new Vector3(xValue, 0, zValue) * Time.deltaTime); }
        else if (rotateZ) { transform.Rotate(new Vector3(xValue, yValue, 0) * Time.deltaTime); }
        else { transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime); }
    }   
}
