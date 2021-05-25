using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController controller = other.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.isDead = true;
            }
        }
        /*
        else if (other.tag == "Spellbook")
        {
            //Do a thing.
        }
        else
        {
            Destroy(other.gameObject);
        }
        */
    }
}
