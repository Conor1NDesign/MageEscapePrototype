using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoGust : MonoBehaviour
{
    public float HieghtOfHeavyObject = 1;
    [HideInInspector]
    GameObject currentlyLifting;
    public GameObject lockPos;
    CharacterController cc;
   
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heavy Object"))
        {
            cc.center = new Vector3(0, -5, 0);
        other.attachedRigidbody.isKinematic = true;
        currentlyLifting = other.gameObject;
            other.transform.position = lockPos.transform.position;
        }
    }
    private void OnDestroy()
    {
        currentlyLifting.GetComponent<Rigidbody>().isKinematic = false;
        currentlyLifting = null;
    }


}
