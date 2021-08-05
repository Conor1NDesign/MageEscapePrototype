using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable
{

    public bool isActivated = false;
    public float downwardOffset = 0.5f;
    public float speedOfCompression = 1;
    Vector3 activatedPos;
    Vector3 deactivatedPos;

    bool hasMovingPlatforms = false;

    public MovingPlatform[] movingPlatforms;
    private void Start()
    {
        deactivatedPos = transform.position;
        activatedPos = transform.position - new Vector3(0, downwardOffset, 0);
        if (movingPlatforms.Length != 0)
        {
            hasMovingPlatforms = true;
        }
    }


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

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {

            transform.position = Vector3.Lerp(transform.position, activatedPos, speedOfCompression / 10 * Time.deltaTime);

            if (hasMovingPlatforms)
            {
                Activated(movingPlatforms);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, deactivatedPos, speedOfCompression / 10 * Time.deltaTime);
            Deactivated(movingPlatforms);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Heavy Object")
        {
            isActivated = true;
            foreach (var item in movingPlatforms)
            {
                item.numberOfActiveSwitches++;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Heavy Object")
        {
            Deactivated();
            isActivated = false;
            foreach (var item in movingPlatforms)
            {
                item.numberOfActiveSwitches--;
            }
        }
    }
}
