using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingGust : MonoBehaviour
{

    public float gustSpeedModifier = 1;
    [HideInInspector]
    public List<GameObject> inBeam;

    private void Start()
    {
        inBeam = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lightable"))
        {
            other.gameObject.GetComponent<Scone>().isActivated = false;
        }

        if (other.CompareTag("Heavy Object"))
        {

        }

        if (other.CompareTag("Player"))
        {
            inBeam.Add(other.gameObject);
        }

        }
        private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // other.gameObject.transform.parent = gameObject.transform;
            other.GetComponent<PlayerController>().useGravity = false;
            other.GetComponent<PlayerController>().Move((transform.forward * gustSpeedModifier) + other.GetComponent<PlayerController>().moveDirection);

        } 
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (var item in inBeam)
        {
            if (item.name == "Player 1" || item.name == "Player 2")
            {
              item.GetComponent<PlayerController>().useGravity = true;
            }
        }
       
    }
    private void OnDrawGizmos()
    {
        
    }
}

