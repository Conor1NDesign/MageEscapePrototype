using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    public bool isActive;
    public List<MovingPlatform> movingPlatforms;
    bool isactivated;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
         NEED TO DO
        ANIMATION
        Functionallity
         
         */
        if (isActive)
        {
            foreach (var item in movingPlatforms)
            {
                item.resetting = true;
                //item.numberOfActiveSwitches++;
                //print("down");
                //isactivated = true;
            }
           // Activated(movingPlatforms);
        }
        else
        {
            if (isactivated)
            {
                foreach (var item in movingPlatforms)
                {
                print("up");
                    item.numberOfActiveSwitches--;
                    isactivated = false;
                }
            }
        }
    }
}
