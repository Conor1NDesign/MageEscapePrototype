﻿using System.Collections;
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
        // if (!other.CompareTag("Spellbook"))
        //{
        print(other.tag);
        if (other.CompareTag("Water"))
        {
            print("ICE ICE BABY");
            frozenMode.MarchTheCubes();
        }
    }
}