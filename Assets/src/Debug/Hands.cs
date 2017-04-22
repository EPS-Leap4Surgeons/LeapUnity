using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LogSuccess(bool success)
    {
        Debug.Log(success ? "Pinch detected" : "Pinch undetected");
    }
}