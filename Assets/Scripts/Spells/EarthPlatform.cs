using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPlatform : MonoBehaviour
{
    public PlayerController playerCasting;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            playerCasting.earthPlatform = null;
            Destroy(gameObject);
        }
    }
}
