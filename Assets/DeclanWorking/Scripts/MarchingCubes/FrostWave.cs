using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWave : MonoBehaviour
{
    ColliderTracker colliderTracker;
    public FrozonMode frozenMode;
    // Start is called before the first frame update
    void Start()
    {
        //frozenMode = FindObjectOfType<FrozonMode>();
        colliderTracker = FindObjectOfType<ColliderTracker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        print(other.tag);
        if (other.CompareTag("Water"))
        {
            frozenMode.MarchTheCubes();
            return;
        }
        else if (other.CompareTag("Lightable"))
        {
            other.GetComponent<Scone>().isActivated = false;
            return;
        }
        SpinningBlade sb = other.GetComponent<SpinningBlade>();
        if (sb!= null)
        {
            sb.isSlowed = true;
            sb.counter = 0;
        }

    }
}
