using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnableTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject portal;
    // Update is called once per frame
    void Update()
    {
        if (playerCount == 2)
        {
            portal.SetActive(true);
        }
        else
        {
            portal.SetActive(false);
        }
    }

    public int playerCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCount++;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCount--;
        }
    }
}
