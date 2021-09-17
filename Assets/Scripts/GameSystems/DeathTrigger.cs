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
        else if (other.tag == "Spellbook")
        {
            SpellbookController controller = other.GetComponent<SpellbookController>();

            if (controller)
            {
                controller.Respawn();
            }
        }
        else if (other.tag == "Heavy Object")
        {
            other.GetComponent<RespawnHeavyObject>().Respawn();
        }

        /*
        else
        {
            Destroy(other.gameObject);
        }
        */
    }
}
