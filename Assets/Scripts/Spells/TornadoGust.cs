using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoGust : MonoBehaviour
{
    public float HieghtOfHeavyObject = 1;
    [HideInInspector]
    public PlayerController caster;
    [HideInInspector]
    GameObject currentlyLifting;
    public GameObject lockPos;
    CharacterController cc;
   
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    float counter = 0;
    public float maxAirTime = 0.5f;
    private void Update()
    {
        if (cc.isGrounded)
        {
            print("Grounded");
            counter = 0.0f;
        }
        else
        {
            counter += Time.deltaTime;
            if (counter > maxAirTime)
            {
                caster.tornadoActive = false;
                caster.tornado = null;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Heavy Object"))
        {
           // cc.center = new Vector3(0, -5, 0);
        other.attachedRigidbody.isKinematic = true;
        currentlyLifting = other.gameObject;
            other.transform.position = lockPos.transform.position;
        }
    }
    private void OnDestroy()
    {
        if (currentlyLifting != null)
        { 
        currentlyLifting.GetComponent<Rigidbody>().isKinematic = false;
        currentlyLifting = null;
        }
    }


}
