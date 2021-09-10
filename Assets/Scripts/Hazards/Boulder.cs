using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public SphereCollider triggerCollider;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // crush player
            PlayerController controller = other.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.isDead = true;
            }
        }
        else if (other.tag == "Spellbook")
        {
            // ignore books?
        }
        else
        {
            triggerCollider.enabled = false;
        }
    }
}
