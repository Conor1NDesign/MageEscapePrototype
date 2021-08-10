using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingGust : MonoBehaviour
{
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
            other.GetComponent<CharacterController>().Move((transform.position- other.gameObject.transform.position).normalized * 10);

        }
    }
}
