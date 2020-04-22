using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropObjects2 : MonoBehaviour
{
    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
    public void Black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    public void Orange()
    {
        GetComponent<Renderer>().material.color = new Color(0.9056604f, 0.5189343f, 0.2947668f, 1f);
    }
    

    private bool IsHeld;
    private GameObject Reticle;
    // Start is called before the first frame update
    void Start()
    {
        IsHeld = false;
        Reticle = GameObject.Find("GvrReticlePointer (1)");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHeld)
        {
            Ray ray = new Ray(Reticle.transform.position, Reticle.transform.forward);
            transform.position = ray.GetPoint(4);
        }

    }

    public void HandleGazeTriggerStart()
    {
        IsHeld = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void HandleGazeTriggerEnd()
    {
        IsHeld = false;
        GetComponent<Renderer>().material.color = new Color(0.9056604f, 0.5189343f, 0.2947668f, 1f);

    }

}
