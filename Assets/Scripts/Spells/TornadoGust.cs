using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoGust : MonoBehaviour
{
    public float HieghtOfHeavyObject = 1;
    [HideInInspector]
    GameObject currentlyLifting;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heavy Object"))
        { 
        
        rb.isKinematic = true;
        other.attachedRigidbody.isKinematic = true;
        currentlyLifting = other.gameObject;
            other.transform.position += new Vector3(0, HieghtOfHeavyObject, 0);
        }
    }


}
