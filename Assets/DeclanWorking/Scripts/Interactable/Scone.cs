using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scone : Interactable
{


    public bool isActivated = false;
    bool hasMovingPlatforms = false;
    bool hasSetSwitchActive = false;
    public MovingPlatform[] movingPlatforms;
    public GameObject particles;
    public Material NonEmmisive;
    private void OnDrawGizmos()
    {
        if (movingPlatforms.Length != 0)
        {
            foreach (var item in movingPlatforms)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, item.GetComponent<MovingPlatform>().Platform.transform.position);
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
            particles.gameObject.SetActive(true);
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
                    
                }
            }
            
        }
        else
        {
            particles.gameObject.SetActive(false);
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
                   
                }
            }
        }

    }
}
