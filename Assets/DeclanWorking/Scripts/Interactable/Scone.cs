﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scone : Interactable
{


    public bool isActivated = false;
    bool hasMovingPlatforms = false;
    bool hasSetSwitchActive = false;
    public MovingPlatform[] movingPlatforms;
    private void OnDrawGizmos()
    {
        if (movingPlatforms.Length != 0)
        {
            foreach (var item in movingPlatforms)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, item.transform.position);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (movingPlatforms.Length != 0)
        {
            hasMovingPlatforms = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {

            if (hasMovingPlatforms)
            {
                if (hasSetSwitchActive == false)
                {
                    foreach (var item in movingPlatforms)
                    {
                        item.numberOfActiveSwitches++;
                        hasSetSwitchActive = true;
                    }
                    Activated(movingPlatforms);
                    //print("activated");
                }
            }
        }
        else
        {
            if (hasMovingPlatforms)
            {

                if (hasSetSwitchActive == true)
                {
                    foreach (var item in movingPlatforms)
                    {
                        item.numberOfActiveSwitches--;
                        hasSetSwitchActive = false;
                    }
                    Deactivated(movingPlatforms);
                    print("deactivated");
                }
            }
        }

    }
}