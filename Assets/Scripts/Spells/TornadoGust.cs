using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoGust : MonoBehaviour
{
    public float HieghtOfHeavyObject = 1;
    [HideInInspector]
    GameObject currentlyLifting;
    public GameObject lockPos;

   
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heavy Object"))
        { 
        other.attachedRigidbody.isKinematic = true;
        currentlyLifting = other.gameObject;
            other.transform.position = lockPos.transform.position;
        }
    }


}
