using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDObject : MonoBehaviour, DragDropHandler
{
    private bool IsHeld;
    private GameObject gazedAt;
    private GameObject Reticle;
    // Start is called before the first frame update
    void Start()
    {
        IsHeld = false;
        GetComponent<Renderer>().material.color = new Color(0.2056604f, 0.5189343f, 0.2947668f, 1f);
        Reticle = GameObject.Find("DDReticle");
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
