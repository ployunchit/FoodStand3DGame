using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDestination;

    void OnMouseDown(){
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDestination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    void OnMouseUp(){
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    // tutorial from https://www.youtube.com/watch?v=IEV64CLZra8&ab_channel=JimmyVegas
}
